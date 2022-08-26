using NickChapsasCourse.Domain;

namespace NickChapsasCourse.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPostById(Guid postId);
    }
}
