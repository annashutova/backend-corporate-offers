#!/bin/bash

set -e

# Wait for the database to be ready
echo "Waiting for the database..."
until pg_isready -h "$DBHOST" -p 5432 -U postgres; do
  sleep 2
done

# Apply database migrations
echo "Applying database migrations..."
dotnet ef database update

# Start the application
exec "$@"
