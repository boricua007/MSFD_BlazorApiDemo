# MSFD Blazor API Demo

.NET 9.0 Blazor WebAssembly Application demonstrating modern web development with external API integration, dynamic content rendering, and GitHub API consumption for the Microsoft Full Stack Developer certification.

## Quick Start

```bash
dotnet run
```

## Features

✅ **Blazor WebAssembly** - Single-page application framework for rich interactive web UIs  
✅ **GitHub API Integration** - Real-time fetching of user profiles and repository content  
✅ **Markdown Rendering** - Dynamic conversion of markdown to HTML using Markdig  
✅ **External API Consumption** - Demonstrates REST API calls to JSONPlaceholder  
✅ **Bootstrap Styling** - Professional, responsive UI design  
✅ **Hot Reload** - Fast development iteration with dotnet watch

**Tech Stack:** .NET 9.0 • C# • Blazor WebAssembly • Bootstrap • Markdig • HttpClient • GitHub API

## API Integration Patterns

| Pattern | Description | Technology | Benefits |
|---------|-------------|------------|----------|
| External APIs | Consuming third-party APIs | HttpClient & IHttpClientFactory | Reusable, testable code |
| CORS Handling | Cross-origin requests | Named HttpClient | Proper separation of concerns |
| Async Operations | Non-blocking API calls | async/await pattern | Better performance |
| JSON Serialization | Data transformation | System.Text.Json | Type-safe deserialization |

## Usage Examples

### Fetching GitHub User Profile

```csharp
var httpClient = HttpClientFactory.CreateClient("ExternalAPI");
httpClient.DefaultRequestHeaders.Add("User-Agent", "MSFD-Blazor-Demo");

var userResponse = await httpClient.GetFromJsonAsync<GitHubUserResponse>(
    "https://api.github.com/users/boricua007");
avatarUrl = userResponse?.AvatarUrl;
```

### Consuming JSONPlaceholder API

```csharp
private async Task FetchUsers()
{
    isLoading = true;
    try
    {
        users = await Http.GetFromJsonAsync<List<User>>(
            "https://jsonplaceholder.typicode.com/users");
    }
    catch (Exception ex)
    {
        errorMessage = $"Error fetching users: {ex.Message}";
    }
    finally
    {
        isLoading = false;
    }
}
```

### Markdown to HTML Conversion

```csharp
var pipeline = new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()
    .Build();
htmlContent = Markdown.ToHtml(markdownContent, pipeline);
```

## Sample Output

```
User Data Page:
Showing 10 users from JSONPlaceholder API

About Page:
Profile avatar displayed with GitHub README rendered as HTML
```

Note: The application demonstrates real-world API consumption with proper error handling and loading states.

## Data Model

```csharp
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
}

public class GitHubUserResponse
{
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }
}
```

## Code Structure Demonstrated

```csharp
// HttpClient configuration for external APIs
builder.Services.AddHttpClient("ExternalAPI", client =>
{
    // No BaseAddress so it can make requests to any URL
});

// Page routing in Blazor
@page "/about"
@inject IHttpClientFactory HttpClientFactory

// Async data loading on component initialization
protected override async Task OnInitializedAsync()
{
    var response = await httpClient.GetFromJsonAsync<T>(url);
}

// Dynamic HTML rendering from markdown
@((MarkupString)htmlContent!)
```

## Learning Objectives

- **Blazor Development:** Building single-page applications with Blazor WebAssembly
- **API Consumption:** Integrating external REST APIs with proper error handling
- **State Management:** Managing component state with async data loading
- **Content Transformation:** Converting markdown to HTML dynamically
- **MSFD Certification:** Demonstrates front-end development competencies for Microsoft Full Stack Developer track

## Project Structure

```
MSFD_BlazorApiDemo/
├── Program.cs                      # Application entry point with DI configuration
├── Pages/
│   ├── Home.razor                  # Landing page with project overview
│   ├── About.razor                 # Dynamic GitHub profile page
│   └── FetchData.razor             # User data from JSONPlaceholder API
├── Layout/
│   ├── MainLayout.razor            # Main application layout
│   └── NavMenu.razor               # Navigation menu
├── wwwroot/
│   ├── index.html                  # Main HTML host
│   └── css/                        # Styling resources
├── MSFD_BlazorApiDemo.csproj       # Project configuration
├── MSFD_BlazorApiDemo.sln          # Solution file
└── README.md                       # This file
```

## Development Workflow

1. **Start the Application:** `dotnet watch`
2. **Explore Features:**
   - Visit Home page for project overview
   - Check About page to see GitHub API integration
   - Test Fetch Data page for user data retrieval
3. **Study Implementation:**
   - Examine API integration patterns
   - Review error handling and loading states
   - Understand component lifecycle with `OnInitializedAsync`

## Getting Started

1. Clone or download the project
2. Navigate to project directory: `cd MSFD_BlazorApiDemo`
3. Restore dependencies: `dotnet restore`
4. Build the application: `dotnet build`
5. Run with hot reload: `dotnet watch`
6. Open browser: `http://localhost:5133`
7. Explore the pages:
   - **Home** - Project overview and features
   - **About** - GitHub profile with dynamic content
   - **Fetch Data** - User data from external API

## Key Concepts Demonstrated

- **Component-Based Architecture:** Building UIs with reusable Blazor components
- **Dependency Injection:** Configuring and using IHttpClientFactory
- **Async Programming:** Non-blocking API calls with async/await
- **Error Handling:** Graceful error management with user feedback
- **External API Integration:** Consuming third-party REST APIs
- **Dynamic Content:** Converting and rendering markdown content

## API Endpoints Used

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| GET | https://api.github.com/users/{username} | Get GitHub user profile | User object with avatar |
| GET | https://api.github.com/repos/{owner}/{repo}/contents/{path} | Get repository file content | Base64 encoded content |
| GET | https://jsonplaceholder.typicode.com/users | Get sample user data | Array of user objects |

## About

.NET 9.0 Blazor WebAssembly Application built for the Microsoft Front-End Development course as part of the Full-Stack Certification track. This application demonstrates modern single-page application development, external API integration, and dynamic content rendering - essential skills for full-stack developers building interactive web applications for the Microsoft Full-Stack Developer Certification track.

## Dependencies

- **Microsoft.AspNetCore.Components.WebAssembly** (9.0.8) - Blazor WebAssembly runtime
- **Markdig** (0.44.0) - Markdown processing library
- **Microsoft.Extensions.Http** (10.0.2) - HttpClient factory and extensions

## Author

**Daisy Viruet-Allen (boricua007)**  
GitHub: [https://github.com/boricua007](https://github.com/boricua007)

---

*This project is part of the Microsoft Full Stack Developer certification coursework.*
