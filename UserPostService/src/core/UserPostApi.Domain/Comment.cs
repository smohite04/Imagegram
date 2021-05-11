using System;

namespace UserPostApi.Domain
{
    public class Comment
    {
        public Comment(string userId, string postId, string content, string commentId)
        {
            userId.ShouldNotBeNullOrEmpty(nameof(userId), nameof(Comment));
            commentId.ShouldNotBeNullOrEmpty(nameof(commentId), nameof(Comment));
            content.ShouldNotBeNullOrEmpty(nameof(content), nameof(Comment));
            postId.ShouldNotBeNullOrEmpty(nameof(postId), nameof(Comment));
            CommentorUserId = userId;
            PostId = postId;
            Id = commentId;
            Content = Content;
        }
        public string Id { get; }
        public string PostId { get; }
        public string Content { get; private set; }

        /// <summary>
        /// Created represents the id associated with user logged-in and who's account needs to be created.
        /// </summary>
        public string CommentorUserId { get; }
        public DateTime CreatedOn { get; private set; }

        public Comment WithCreatedOn(DateTime dateTime)
        {
            dateTime.ShouldBeAValidDate(nameof(dateTime), nameof(Comment), nameof(WithCreatedOn));
            CreatedOn = dateTime;
            return this;
        }
    }
}
