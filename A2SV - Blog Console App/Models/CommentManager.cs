using A2SV___Blog_CRUD.Models;

namespace A2SV___Blog_CRUD
{
    public class CommentManager
    {
        private readonly A2svBackendLearningContext DbContext;

        public CommentManager(A2svBackendLearningContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddCommentToPost(int postId, string comment)
        {
            var post = DbContext.Posts.Find(postId);

            if (post != null)
            {
                var newComment = new Comment
                {
                    Text = comment,
                    CreatedAt = DateTime.Now
                };

                post.Comments.Add(newComment);
                DbContext.SaveChanges();
            }
        }

        public void UpdateCommentOnPost(int postId, int commentId, string comment)
        {
            var post = DbContext.Posts.Find(postId);

            if (post != null)
            {
                var commentToUpdate = post.Comments.FirstOrDefault(c => c.Id == commentId);

                if (commentToUpdate != null)
                {
                    commentToUpdate.Text = comment;
                    DbContext.SaveChanges();
                }
            }
        }

        public void DeleteCommentFromPost(int postId, int commentId)
        {
            var post = DbContext.Posts.Find(postId);

            if (post == null) return;

            var comment = DbContext.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null) return;

            DbContext.Comments.Remove(comment);
            DbContext.SaveChanges();
        }
    }
}