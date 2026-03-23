-- Enable the pgvector extension (run once per database)
CREATE EXTENSION IF NOT EXISTS vector;

-- Template for creating a vector store table
-- Replace {table_name} with your actual table name (e.g., course_embeddings)
-- Replace {dimensions} with your embedding model's dimension count (e.g., 1536 for text-embedding-ada-002)

CREATE TABLE IF NOT EXISTS {table_name} (
    id TEXT PRIMARY KEY,
    embedding vector({dimensions}),
    metadata JSONB NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
);

-- Create an index for efficient vector similarity search using cosine distance
CREATE INDEX IF NOT EXISTS {table_name}_embedding_idx ON {table_name}
USING ivfflat (embedding vector_cosine_ops) WITH (lists = 100);

-- Optional: Create a GIN index on metadata for efficient filtering
CREATE INDEX IF NOT EXISTS {table_name}_metadata_idx ON {table_name} USING GIN (metadata);
