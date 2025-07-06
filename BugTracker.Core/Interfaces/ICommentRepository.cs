using BugTracker.Core.Models;


namespace BugTracker.Core.Interfaces
{
    public interface ICommentRepository
    {

        //Get comment
        Task<Comment?> GetcommentByIdAsync(int id);

        //Get All comments
        Task<IEnumerable<Comment>> GetAllCommentsAsync();

        //Create comment
        Task CreatecommentAsync(Comment comment);

        //Update comment
        void UpdatecommentAsync(Comment id);

        //Delete comment
        void DeletecommentAsync(int id);
    }
}
