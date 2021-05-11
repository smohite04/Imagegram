using System;

namespace UserPostApi.Domain
{
    public class Post
    {
        public Post(string imageUrl, string userId, string postId)
        {
            userId.ShouldNotBeNullOrEmpty(nameof(userId), nameof(Post));
            imageUrl.ShouldNotBeNullOrEmpty(nameof(imageUrl), nameof(Post));
            postId.ShouldNotBeNullOrEmpty(nameof(postId), nameof(Post));
            CreatorUserId = userId;
            Id = postId;
            ImageUrl = imageUrl;
        }
        public string Id { get; }
        /// <summary>
        /// Created represents the id associated with user logged-in and who's account needs to be created.
        /// </summary>
        public string CreatorUserId { get; }
        public DateTime CreatedOn { get; private set; }
        public string ImageUrl { get; }

        public Post WithCreatedOn(DateTime dateTime)
        {
            dateTime.ShouldBeAValidDate(nameof(dateTime), nameof(Comment), nameof(WithCreatedOn));
            CreatedOn = dateTime;
            return this;
        }
    }
}
