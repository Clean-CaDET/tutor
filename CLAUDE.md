# Tutor - Educational Platform

An intelligent tutoring system for structured learning with knowledge and skill mastery tracking.

**Stack:** .NET 10.0 modular monolith | EF Core + PostgreSQL | JWT Auth | Semantic Kernel (AI)

## Architecture

Projects organized as 6 domain modules, each with 4 layers, plus shared BuildingBlocks and host.

**Layer Responsibilities:**
- **API** - Public contracts, DTOs, internal service interfaces (what other modules can consume)
- **Core** - Domain entities, business logic, domain services (no external dependencies)
- **Infrastructure** - EF Core DbContext, repositories, external integrations
- **Tests** - Integration tests using Tutor.API, unit tests

**Key Rules:**
- Cross-module communication only through API layer interfaces
- Core never references Infrastructure (dependency inversion)
- Modules reference other modules' API projects only, never Core

### BuildingBlocks (shared kernel)
- `BuildingBlocks.Core` - Base entity classes, common interfaces, Result types
- `BuildingBlocks.Infrastructure` - Generic repository, DbContext base, JSON handling
- `BuildingBlocks.AI.Core` - AI service abstractions
- `BuildingBlocks.AI.Infrastructure` - Semantic Kernel implementations
- `BuildingBlocks.Tests` - Test fixtures, base test classes

### Host
- `Tutor.API` - ASP.NET Core Web API, composes all modules, Swagger, auth middleware
- `Tutor.Architecture.Tests` - ArchUnit tests enforcing architectural rules

## Modules

### Courses
**Domain:** Orchestrates the learning experience by organizing content into courses and units, managing who can teach and learn, and tracking learner progress through weekly feedback cycles.

**Key Entities:**
- **Course** - Top-level container (code, name, description, startDate, isArchived)
- **KnowledgeUnit** - Weekly learning unit within a course, contains Reflections, KCs, Tasks
- **LearnerGroup** - Groups learners for easier management and monitoring
- **WeeklyFeedback** - Instructor's weekly assessment of learner progress (Red/Yellow/Green semaphore + comment)
- **Reflection** - Structured questions for learners to reflect on their learning
- **Enrollment** - Tracks which learners are enrolled in which units

**Use Cases:**
- **Authoring**: Instructors create and configure courses, define weekly units with learning objectives, clone existing courses as templates, archive completed courses, create reflection questions
- **Enrollment**: Admins assign instructors as course owners, create learner groups, manage group memberships, bulk enroll/unenroll learners from units
- **Learning**: Learners view their enrolled courses, access unit content based on visibility rules (date-based unlocking), submit answers to reflection questions
- **Monitoring**: Instructors track which learners are enrolled per unit, monitor group activity levels, provide weekly feedback with progress semaphores (Red=struggling, Yellow=okay, Green=good)
- **Analytics**: System calculates unit progress ratings, aggregates weekly activity metrics (tasks completed, KCs mastered)
- **Supervision**: Admins view active courses with aggregated learner feedback, generate reports with meaningful reflections and feedback patterns

**Dependencies:** → Stakeholders.API, KnowledgeComponents.API, LearningTasks.API

### KnowledgeComponents (KC)
**Domain:** Manages atomic units of knowledge that learners must master. Handles the learning session lifecycle, presents assessments and instructional content, evaluates submissions, and tracks mastery progression.

**Key Entities:**
- **KnowledgeComponent** - Atomic learning objective (code, name, expectedDuration)
- **AssessmentItem** - Questions to test understanding: MCQ (single choice), MRQ (multiple choice), SAQ (short answer)
- **InstructionalItem** - Learning content: Text, Video, or Image with ordering
- **Submission** - Learner's answer to an assessment item
- **Evaluation** - Feedback on a submission (correct/incorrect, hints, explanations)
- **KcMastery** - Tracks whether a learner has mastered a KC

**Use Cases:**
- **Authoring**: Instructors create KCs with expected duration, add/reorder assessment items (MCQ/MRQ/SAQ with feedback patterns), add/reorder instructional items (text/video/image), clone KCs for reuse
- **Learning**: Learners launch a learning session for a KC, system selects appropriate assessment items based on progress, learners view instructional content, submit answers and receive immediate evaluation with feedback, can pause/continue/terminate sessions
- **Mastery**: System tracks completion (all items seen) and passing (sufficient correct answers), applies move-on criteria to determine if KC is satisfied, records mastery status
- **Analytics**: Instructors view KC statistics (submission counts, correctness rates), system detects common misconceptions from wrong answer patterns, tracks most frequent errors per assessment

**Dependencies:** → Courses.API (for unit context)

### LearningTasks
**Domain:** Provides structured, multi-step tasks that develop learners' skills through practical exercises. Supports scaffolded learning with examples and guidance, tracks step-by-step progress, and enables instructor grading.

**Key Entities:**
- **LearningTask** - A practical exercise (name, description, maxPoints, isTemplate)
- **Activity** - A step within a task, contains examples, guidance text, and submission requirements
- **TaskProgress** - Overall progress on a task (started, completed, graded status)

**Use Cases:**
- **Authoring**: Instructors create tasks with multiple steps (activities), define examples with video walkthroughs, write guidance text for each step, specify submission format and point values, clone tasks as templates, move tasks between units
- **Learning**: Learners view task list for a unit with progress summaries, open a task to see step-by-step instructions, access examples (watch videos with play/pause/finish tracking), read guidance materials, submit answers for each step
- **Progress**: System creates/updates task progress records, tracks which steps are completed, records submission timestamps and content
- **Grading**: Instructors view learner submissions, grade individual steps with points and comments, view group summaries showing progress across all learners, bulk retrieve progress for a cohort

**Dependencies:** → Courses.API (for unit context)

### LearningUtils
**Domain:** Provides supporting tools for learners during their learning journey.

**Key Entities:**
- **Note** - Learner's personal note (text, order) scoped to a specific unit within a course

**Use Cases:**
- **Note-taking**: Learners create notes while studying a unit, update note content, reorder notes, delete notes, retrieve all notes for a unit

**Dependencies:** → Stakeholders.API (for learner context)

### Stakeholders
**Domain:** Manages user identities, authentication, and the two primary roles in the system: instructors who create content and monitor progress, and learners who consume content and complete tasks.

**Key Entities:**
- **User** - Base authentication account (username, passwordHash)
- **Stakeholder** - Abstract base for roles, contains profile info (name, surname, email, isArchived)
- **Instructor** - Can author content, monitor learners, provide feedback
- **Learner** - Can enroll in courses, complete KCs and tasks, receive feedback
- **AuthenticationTokens** - JWT access token + refresh token pair

**Use Cases:**
- **Authentication**: Users login with credentials to receive JWT tokens, refresh expired access tokens using refresh token, logout invalidates tokens
- **Learner Management**: Admins register learners individually or bulk import from CSV/list, retrieve paginated learner lists with filtering, update learner profile information, archive learners (soft delete preserving history), permanently delete learners
- **Instructor Management**: Admins register instructor accounts, retrieve instructor lists, update instructor profiles, archive or delete instructors

**Dependencies:** Foundation module - all other modules depend on Stakeholders for user identity

## Controllers (Tutor.API)

Controllers are organized by audience and domain in `Tutor.API/Controllers/`:
- `Administrator/` - Admin-only endpoints (course management, enrollments, monitoring)
- `Instructor/` - Instructor endpoints (authoring, grading, feedback)
- `Learner/` - Learner endpoints (learning sessions, submissions, progress)

**Controller Conventions:**
- Inherit from `BaseApiController` for standardized response handling
- Use `CreateResponse(Result)` to convert FluentResults to HTTP responses
- Apply `[Authorize(Policy = "...Policy")]` for role-based access:
  - `administratorPolicy` - Admin only
  - `instructorPolicy` - Instructors only
  - `learnerPolicy` - Learners only
- Extract user IDs from JWT claims using extension methods:
  - `User.InstructorId()` - Get instructor ID from claims
  - `User.LearnerId()` - Get learner ID from claims
  - Import `Tutor.Stakeholders.Infrastructure.Authentication` namespace
- Route patterns follow RESTful conventions with route parameters as `{param:int}`
- Controller constructor injects service interfaces from module API layers

## AI Capabilities (BuildingBlocks.AI)

Generic AI services available for module-specific features. Core defines abstractions; Infrastructure provides Semantic Kernel + pgvector implementations.

**Services:**
- `IAiChatService` - Chat completions with `CompleteAsync` (returns full response) and `StreamAsync` (token streaming). Configure via `CompletionRequest` (messages, system prompt, temperature, max tokens).
- `ITextEmbeddingService` - Convert text to vectors via `GenerateEmbeddingAsync` (single) or `GenerateEmbeddingsAsync` (batch).
- `IVectorStore<TMetadata>` - Store/search embeddings with custom metadata. Supports `UpsertAsync`, `SearchAsync` (cosine similarity with filters), `DeleteAsync`. Each module registers its own instance with `AddVectorStore<TMetadata>()`.

**Registration:**
```csharp
// In module startup - register shared AI services
services.AddAIServices(new AiServiceConfiguration
{
    ApiKey = "...",
    ChatModelId = "gpt-4o",
    EmbeddingModelId = "text-embedding-3-small" // optional
});

// Per-module vector store with custom metadata
services.AddVectorStore<MyMetadata>(new VectorStoreConfiguration
{
    ConnectionString = "...",
    TableName = "my_module_vectors",
    VectorDimensions = 1536
});
```

**Usage Pattern (RAG):**
1. Generate embedding for user query via `ITextEmbeddingService`
2. Search relevant content via `IVectorStore<T>.SearchAsync`
3. Build prompt with retrieved context
4. Call `IAiChatService.CompleteAsync` or `StreamAsync`

## BuildingBlocks Reference

### When to Use Each Domain Building Block (Core)

| Building Block | Use When | Example |
|----------------|----------|---------|
| `Entity` | Any domain object needing persistence and identity | `Course : Entity`, `Note : Entity` |
| `AggregateRoot` | Entity is the root of a consistency boundary (aggregate) | `LearningTask : AggregateRoot` |
| `ValueObject` | Object defined by attributes, not identity; immutable | `WeeklyFeedbackItem : ValueObject` |
| `EventSourcedAggregateRoot` | Need audit trail, analytics, or rebuild state from events | `KnowledgeComponentMastery : EventSourcedAggregateRoot` |
| `DomainEvent` | Recording state changes as events | `KnowledgeComponentStarted`, `TaskCompleted` |

**Entity vs AggregateRoot:** Use `AggregateRoot` when the entity is the entry point for a cluster of related objects that must be consistent together. Child entities within that cluster use plain `Entity`.

Do not use **EventSourcedAggregateRoot**, as it is a legacy feature.

### When to Use Each Use Case Building Block (Core)

| Building Block | Use When | Example |
|----------------|----------|---------|
| `BaseService<TDto, TDomain>` | Service needs DTO↔Domain mapping but custom persistence logic | Custom services with AutoMapper |
| `CrudService<TDto, TDomain>` | Service needs standard Create/Read/Update/Delete operations | `NoteService : CrudService<NoteDto, Note>` |
| `ICrudRepository<TEntity>` | Defining repository interface for Core layer | `INoteRepository : ICrudRepository<Note>` |
| `IUnitOfWork` | Coordinating saves across multiple repositories | Transaction management in services |
| `FailureCode` | Returning standardized errors with HTTP codes | `Result.Fail(FailureCode.NotFound)` |

**BaseService vs CrudService vs no inheritance:** Use `CrudService` when you need the standard CRUD operations out of the box. Use `BaseService` when you only need the mapping utilities but will implement persistence differently. Do not inherite either service when creating a service that works with multiple entities without a clear main entity.

When creating a DTO and matching domain object in a Module.Core project, look for the Mappers directory and expand the AutoMapper profiles to simplify service implementations.

### When to Use Each Infrastructure Building Block

| Building Block | Use When | Example |
|----------------|----------|---------|
| `CrudDatabaseRepository<TEntity, TDbContext>` | Implementing ICrudRepository with EF Core | `LearningTaskDatabaseRepository : CrudDatabaseRepository<LearningTask, LearningTasksContext>` |
| `UnitOfWork<TDbContext>` | Implementing IUnitOfWork for a module's DbContext | Module startup registration |
| `LinqExtensions.GetPagedById` | Paginated queries with default Id ordering | Custom repository methods |
| `LinqExtensions.GetPaged` | Paginated queries with custom ordering | Custom repository methods |
| `DbConnectionStringBuilder.Build` | Building PostgreSQL connection string from env vars | DbContext configuration |
| `EnvironmentConnection.GetSecret` | Reading Docker secrets or env vars | Database password, API keys |
| `LoggingInterceptor` | Automatic logging of service call results | Cross-cutting logging concern |
| `ProxiedServiceExtensions.AddProxiedScoped` | Register service with interceptors (e.g., logging) | Module DI registration |

# Code generation guidelines

## 1. Think Before Coding

**Don't assume. Don't hide confusion. Surface tradeoffs.**

Before implementing:
- State your assumptions explicitly. If uncertain, ask.
- If multiple interpretations exist, present them - don't pick silently.
- If a simpler approach exists, say so. Push back when warranted.
- If something is unclear, stop. Name what's confusing. Ask.

## 2. Simplicity First

**Minimum code that solves the problem. Nothing speculative.**

- No features beyond what was asked.
- No abstractions for single-use code.
- No "flexibility" or "configurability" that wasn't requested.
- No error handling for impossible scenarios.
- If you write 200 lines and it could be 50, rewrite it.

Ask yourself: "Would a senior engineer say this is overcomplicated?" If yes, simplify.

## 3. Surgical Changes

**Touch only what you must. Clean up only your own mess.**

When editing existing code:
- Don't "improve" adjacent code, comments, or formatting.
- Don't refactor things that aren't broken.
- Match existing style, even if you'd do it differently.
- If you notice unrelated dead code, mention it - don't delete it.

When your changes create orphans:
- Remove imports/variables/functions that YOUR changes made unused.
- Don't remove pre-existing dead code unless asked.

The test: Every changed line should trace directly to the user's request.

## 4. Goal-Driven Execution

**Define success criteria. Loop until verified.**

Transform tasks into verifiable goals:
- "Add validation" → "Write tests for invalid inputs, then make them pass"
- "Fix the bug" → "Write a test that reproduces it, then make it pass"
- "Refactor X" → "Ensure tests pass before and after"

For multi-step tasks, state a brief plan:
```
1. [Step] → verify: [check]
2. [Step] → verify: [check]
3. [Step] → verify: [check]
```

Strong success criteria let you loop independently. Weak criteria ("make it work") require constant clarification.

# Style guidelines
- Methods with 3 or less parameters should have their headers and invocations fit into one row.
- Methods with more than 3 parameters should have their headers and invocations separate into multiple rows, where each row should contain 3 parameters.
- Do not write method headers and invocations where one row is one parameter.