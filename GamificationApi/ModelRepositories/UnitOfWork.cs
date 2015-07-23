using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GamificationApi.Models;

namespace GamificationApi.ModelRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context = new GameContext();
        // Repositories
        private IGenericRepository<Player> _playerRepository;
        private IGenericRepository<Assignment> _assignmentRepository;
        private IGenericRepository<AssignmentType> _assignmentTypeRepository;
        private IGenericRepository<Achievement> _achievementRepository;
        private IGenericRepository<Level> _levelRepository;
        private IGenericRepository<JobPointPurchase> _jobPointPurchaseRepository;

        // "Duplicate" this method for more repositories
        public IGenericRepository<Player> PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new GenericRepository<Player>(_context);
                }
                return _playerRepository;
            }
        }

        public IGenericRepository<Assignment> AssignmentRepository
        {
            get
            {
                if (_assignmentRepository == null)
                {
                    _assignmentRepository = new GenericRepository<Assignment>(_context);
                }
                return _assignmentRepository;
            }
        }

        public IGenericRepository<AssignmentType> AssignmentTypeRepository
        {
            get
            {
                if (_assignmentTypeRepository == null)
                {
                    _assignmentTypeRepository = new GenericRepository<AssignmentType>(_context);
                }
                return _assignmentTypeRepository;
            }
        }

        public IGenericRepository<Achievement> AchievementRepository
        {
            get
            {
                if (_achievementRepository == null)
                {
                    _achievementRepository = new GenericRepository<Achievement>(_context);
                }
                return _achievementRepository;
            }
        }

        public IGenericRepository<Level> LevelRepository
        {
            get
            {
                if (_levelRepository == null)
                {
                    _levelRepository = new GenericRepository<Level>(_context);
                }
                return _levelRepository;
            }
        }

        public IGenericRepository<JobPointPurchase> JobPointPurchaseRepository
        {
            get
            {
                if (_jobPointPurchaseRepository == null)
                {
                    _jobPointPurchaseRepository = new GenericRepository<JobPointPurchase>(_context);
                }
                return _jobPointPurchaseRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}