using BugTracker.Core.Interfaces;
using BugTracker.Core.Models;
using BugTracker.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BugTrackerContext _context;

        public CommentRepository(BugTrackerContext context)
        {
            _context = context;
        }

        public Task CreatecommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeletecommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> GetcommentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatecommentAsync(Comment id)
        {
            throw new NotImplementedException();
        }
    }
}
