using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFPowerVote.Models;

namespace EFPowerVote.Services
{
    public interface IOperation
    {
        #region 获取投票部分信息
        /// <summary>
        /// 获取用户信息，如果没就创建
        /// </summary>
        /// <returns></returns>
        efusers GetUser(string openid);
        #endregion

        #region 投票
        /// <summary>
        /// 投票 其实是更新投票
        /// </summary>
        /// <param name="openid"></param>
        /// <returns>返回相应的信息</returns>
        efusers SetVote(string openid, Ticket ticket);


        #endregion

        #region 获取投票信息
        /// <summary>
        /// 获取不同票种的数量
        /// </summary>
        /// <returns>返回[软实力,硬实力]数组</returns>
        int[] GetVote();

        #endregion


    }
}
