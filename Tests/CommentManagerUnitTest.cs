using A2SV___Blog_CRUD;
using A2SV___Blog_CRUD.Models;

namespace Tests;

public class CommentManagerUnitTest : InMemoryDatabaseTestBase
{
    [Fact]
    public void AddComment()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var commentManager = new CommentManager(_context);
        var postManager = new PostManager(_context);
        
        postManager.CreatePost("title", "content");
        Assert.Single(_context.Posts);
        Assert.Equal("title", postManager.ReadAllPosts().First().Title);
        Assert.Equal("content", postManager.ReadAllPosts().First().Content);
        
        commentManager.AddCommentToPost(1, "comment for post 1");
        Assert.Single(_context.Comments);
        Assert.Equal("comment for post 1", _context.Comments.First().Text);
        Assert.Equal(1, _context.Comments.First().PostId);
    }

    [Fact]
    public void EditComment()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var commentManager = new CommentManager(_context);
        var postManager = new PostManager(_context);
        
        // add a post
        postManager.CreatePost("title", "content");
        Assert.Single(_context.Posts);
        Assert.Equal("title", postManager.ReadAllPosts().First().Title);
        Assert.Equal("content", postManager.ReadAllPosts().First().Content);
        
        // add comment to the post
        commentManager.AddCommentToPost(1, "comment for post 1");
        Assert.Single(_context.Comments);
        Assert.Equal("comment for post 1", _context.Comments.First().Text);
        Assert.Equal(1, _context.Comments.First().PostId);
        
        // edit the comment
        commentManager.UpdateCommentOnPost(1, 1, "updated comment");
        Assert.Single(_context.Comments);
        Assert.Equal("updated comment", _context.Comments.First().Text);
        Assert.Equal(1, _context.Comments.First().PostId);
    }

    [Fact]
    public void DeleteComment()
    {
        using var _context = new A2svBackendLearningContext(_options);
        var commentManager = new CommentManager(_context);
        var postManager = new PostManager(_context);
        
        // add a post
        postManager.CreatePost("title", "content");
        Assert.Single(_context.Posts);
        Assert.Equal("title", postManager.ReadAllPosts().First().Title);
        Assert.Equal("content", postManager.ReadAllPosts().First().Content);
        
        // add comment to the post
        commentManager.AddCommentToPost(1, "comment for post 1");
        Assert.Single(_context.Comments);
        Assert.Equal("comment for post 1", _context.Comments.First().Text);
        Assert.Equal(1, _context.Comments.First().PostId);
        
        // delete the comment
        commentManager.DeleteCommentFromPost(1, 1);
        Assert.Empty(_context.Comments);
    }
}