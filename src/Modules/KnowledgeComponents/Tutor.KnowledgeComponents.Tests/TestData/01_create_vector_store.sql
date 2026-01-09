-- Enable pgvector extension
CREATE EXTENSION IF NOT EXISTS vector;

-- Create instructional item embeddings table
CREATE TABLE IF NOT EXISTS "knowledgeComponents"."EmbeddingsInstructionalItems" (
    id TEXT PRIMARY KEY,
    embedding vector(1536),  -- Adjust dimension based on your embedding model
    metadata JSONB NOT NULL,
    created_at TIMESTAMP NOT NULL
);

-- Create index for vector similarity search
CREATE INDEX IF NOT EXISTS instructional_item_embeddings_embedding_idx 
ON "knowledgeComponents"."EmbeddingsInstructionalItems"
USING ivfflat (embedding vector_cosine_ops);