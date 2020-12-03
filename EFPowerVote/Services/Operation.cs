using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFPowerVote.Models;
using Newtonsoft.Json;

namespace EFPowerVote.Services
{
    public class Operation : IOperation
    {
        private readonly piecesServerDbContext _dbContext;
        public Operation(piecesServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region 获取投票部分信息

        public efusers GetUser(string openid)
        {
            efusers info = _dbContext.efusers.Where(c => c.openid == openid).FirstOrDefault();
            if (info == null)
            {//并没有此人的记录 就创建记录
                info = new efusers(openid);
                _dbContext.efusers.Add(info);
                _dbContext.SaveChanges();
            }
            return info;
        }

     
        #endregion

        #region 投票
        public efusers SetVote(string openid, Ticket ticket)
        {
            efusers efuser = _dbContext.efusers.Where(c=>c.openid==openid).FirstOrDefault();
            //判断vote是不是 0 或 1 如果不是 不变投票
            if(ticket.vote==1 || ticket.vote == 0)
            {
                efuser.vote = ticket.vote;
            }
            efuser.reason = ticket.reason;
            efuser.updateTime = DateTime.Now;
            _dbContext.Attach<efusers>(efuser);
            _dbContext.Entry(efuser).Property(c => c.vote).IsModified = true;
            _dbContext.Entry(efuser).Property(c => c.reason).IsModified = true;
            _dbContext.Entry<efusers>(efuser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return efuser;
        }
        #endregion

        #region 返回各种投票信息
        public int[] GetVote()
        {
            //这个需要在写写，因为如果有点没票数的时候，没数据 为 [] 表示两个都为0  [2] 表示一个为0
            //所以不能简单的写就一句了  多写点 
            
            List<int> ts= _dbContext.efusers.Where(c => c.vote == 0 || c.vote == 1).Select(c => c.vote).ToList();
            int[] votenum = new int[] { 0,0};
            if (ts != null)
            {
                if (ts.Count > 0)
                {
                    foreach(int t in ts)
                    {
                        if (t == 0)
                        {
                            votenum[0]++;
                        }
                        else
                        {
                            votenum[1]++;
                        }
                    }
                }
            }
            return votenum;
            //return _dbContext.efusers.Where(c=>c.vote!=-1).GroupBy(c => c.vote).Select(c=>c.Count());
        }
        #endregion

       
    }
}
