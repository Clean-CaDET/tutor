using FluentResults;
using Npgsql;
using Pgvector;
using System.Text.Json;
using Tutor.BuildingBlocks.AI.Core.VectorStores;

namespace Tutor.BuildingBlocks.AI.Infrastructure.VectorStores;

/// <summary>
/// PostgreSQL pgvector implementation of vector storage.
/// </summary>
public class PgVectorStore<TMetadata> : IVectorStore<TMetadata> where TMetadata : class
{
    private readonly VectorStoreConfiguration _configuration;
    private readonly NpgsqlDataSource _dataSource;

    public PgVectorStore(VectorStoreConfiguration configuration)
    {
        _configuration = configuration;
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(_configuration.ConnectionString);
        dataSourceBuilder.EnableDynamicJson();
        dataSourceBuilder.UseVector();
        _dataSource = dataSourceBuilder.Build();
    }

    public async Task<Result> UpsertAsync(VectorRecord<TMetadata> record, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var sql = $@"
                INSERT INTO {_configuration.TableName} (id, embedding, metadata, created_at)
                VALUES (@id, @embedding, @metadata, @created_at)
                ON CONFLICT (id) DO UPDATE SET
                    embedding = EXCLUDED.embedding,
                    metadata = EXCLUDED.metadata,
                    created_at = EXCLUDED.created_at";

            await using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", record.Id);
            command.Parameters.AddWithValue("embedding", new Vector(record.Embedding.ToArray()));
            command.Parameters.AddWithValue("metadata", JsonSerializer.Serialize(record.Metadata));
            command.Parameters.AddWithValue("created_at", record.CreatedAt);

            await command.ExecuteNonQueryAsync(cancellationToken);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to upsert vector record: {ex.Message}");
        }
    }

    public async Task<Result> UpsertBatchAsync(IEnumerable<VectorRecord<TMetadata>> records, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            await using var transaction = await connection.BeginTransactionAsync(cancellationToken);

            var sql = $@"
                INSERT INTO {_configuration.TableName} (id, embedding, metadata, created_at)
                VALUES (@id, @embedding, @metadata, @created_at)
                ON CONFLICT (id) DO UPDATE SET
                    embedding = EXCLUDED.embedding,
                    metadata = EXCLUDED.metadata,
                    created_at = EXCLUDED.created_at";

            foreach (var record in records)
            {
                await using var command = new NpgsqlCommand(sql, connection, transaction);
                command.Parameters.AddWithValue("id", record.Id);
                command.Parameters.AddWithValue("embedding", new Vector(record.Embedding.ToArray()));
                command.Parameters.Add("metadata", NpgsqlTypes.NpgsqlDbType.Jsonb).Value = record.Metadata;
                command.Parameters.AddWithValue("created_at", record.CreatedAt);

                await command.ExecuteNonQueryAsync(cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to upsert vector records: {ex.Message}");
        }
    }

    public async Task<Result<VectorRecord<TMetadata>>> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var sql = $"SELECT id, embedding, metadata, created_at FROM {_configuration.TableName} WHERE id = @id";

            await using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", id);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (!await reader.ReadAsync(cancellationToken))
            {
                return Result.Fail<VectorRecord<TMetadata>>($"Vector record with id '{id}' not found");
            }

            var record = new VectorRecord<TMetadata>
            {
                Id = reader.GetString(0),
                Embedding = new ReadOnlyMemory<float>(reader.GetFieldValue<Vector>(1).ToArray()),
                Metadata = JsonSerializer.Deserialize<TMetadata>(reader.GetString(2))!,
                CreatedAt = reader.GetDateTime(3)
            };

            return Result.Ok(record);
        }
        catch (Exception ex)
        {
            return Result.Fail<VectorRecord<TMetadata>>($"Failed to get vector record: {ex.Message}");
        }
    }

    public async Task<Result<IReadOnlyList<VectorSearchResult<TMetadata>>>> SearchAsync(VectorSearchQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var whereConditions = new List<string> { "1 - (embedding <=> @queryEmbedding) >= @minSimilarity" };
            var parameters = new Dictionary<string, object>
            {
                ["queryEmbedding"] = new Vector(query.QueryEmbedding.ToArray()),
                ["minSimilarity"] = query.MinimumSimilarity,
                ["topK"] = query.TopK
            };

            if (query.MetadataFilters != null && query.MetadataFilters.Any())
            {
                var filterIndex = 0;
                foreach (var filter in query.MetadataFilters)
                {
                    var paramName = $"filter_{filterIndex}";
                    whereConditions.Add($"metadata->>'{filter.Key}' = @{paramName}");
                    parameters[paramName] = filter.Value.ToString()!;
                    filterIndex++;
                }
            }

            var sql = $@"
                SELECT id, embedding, metadata, created_at, 1 - (embedding <=> @queryEmbedding) AS similarity
                FROM {_configuration.TableName}
                WHERE {string.Join(" AND ", whereConditions)}
                ORDER BY similarity DESC
                LIMIT @topK";

            await using var command = new NpgsqlCommand(sql, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            var results = new List<VectorSearchResult<TMetadata>>();

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                var record = new VectorRecord<TMetadata>
                {
                    Id = reader.GetString(0),
                    Embedding = new ReadOnlyMemory<float>(reader.GetFieldValue<Vector>(1).ToArray()),
                    Metadata = JsonSerializer.Deserialize<TMetadata>(reader.GetString(2))!,
                    CreatedAt = reader.GetDateTime(3)
                };

                var similarity = reader.GetDouble(4);

                results.Add(new VectorSearchResult<TMetadata>
                {
                    Record = record,
                    SimilarityScore = similarity
                });
            }

            return Result.Ok<IReadOnlyList<VectorSearchResult<TMetadata>>>(results);
        }
        catch (Exception ex)
        {
            return Result.Fail<IReadOnlyList<VectorSearchResult<TMetadata>>>($"Failed to search vector records: {ex.Message}");
        }
    }

    public async Task<Result> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var sql = $"DELETE FROM {_configuration.TableName} WHERE id = @id";

            await using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", id);

            var rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);

            if (rowsAffected == 0)
            {
                return Result.Fail($"Vector record with id '{id}' not found");
            }

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to delete vector record: {ex.Message}");
        }
    }

    public async Task<Result> DeleteBatchAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var sql = $"DELETE FROM {_configuration.TableName} WHERE id = ANY(@ids)";

            await using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("ids", ids.ToArray());

            await command.ExecuteNonQueryAsync(cancellationToken);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to delete vector records: {ex.Message}");
        }
    }

    public async Task<Result<int>> DeleteByMetadataAsync(Dictionary<string, object> metadataFilters, CancellationToken cancellationToken = default)
    {
        if (metadataFilters == null || !metadataFilters.Any())
        {
            return Result.Fail<int>("At least one metadata filter is required");
        }

        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);

            var whereConditions = new List<string>();
            var parameters = new Dictionary<string, object>();

            var filterIndex = 0;
            foreach (var filter in metadataFilters)
            {
                var paramName = $"filter_{filterIndex}";
                whereConditions.Add($"metadata->>'{filter.Key}' = @{paramName}");
                parameters[paramName] = filter.Value.ToString()!;
                filterIndex++;
            }

            var sql = $@"
                DELETE FROM {_configuration.TableName}
                WHERE {string.Join(" AND ", whereConditions)}";

            await using var command = new NpgsqlCommand(sql, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            var rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            return Result.Ok(rowsAffected);
        }
        catch (Exception ex)
        {
            return Result.Fail<int>($"Failed to delete vector records by metadata: {ex.Message}");
        }
    }
}
