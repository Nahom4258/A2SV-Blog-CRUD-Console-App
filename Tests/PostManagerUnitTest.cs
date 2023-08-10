using A2SV___Blog_CRUD;
using A2SV___Blog_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class PostManagerUnitTest : InMemoryDatabaseTestBase
{
    [Fact]
    public void AddPost()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var postManager = new PostManager(_context);
        postManager.CreatePost("title", "content");

        Assert.Single(_context.Posts);
        Assert.Equal("title", _context.Posts.First().Title);
        Assert.Equal("content", _context.Posts.First().Content);
    }

    [Fact]
    public void EditPost()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var postManager = new PostManager(_context);
        
        postManager.CreatePost("oldTitle", "oldContent");
        Assert.Single(_context.Posts);
        Assert.Equal("oldTitle", _context.Posts.First().Title);
        Assert.Equal("oldContent", _context.Posts.First().Content);
        
        postManager.UpdatePost(1, "newTitle", "newContent");
        
        Assert.Single(_context.Posts);
        Assert.Equal("newTitle", _context.Posts.First().Title);
        Assert.Equal("newContent", _context.Posts.First().Content);
    }
    
    [Fact]
    public void DeletePost()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var postManager = new PostManager(_context);
        
        postManager.CreatePost("title", "content");
        
        postManager.DeletePost(1);
        
        Assert.Empty(_context.Posts);
    }
}