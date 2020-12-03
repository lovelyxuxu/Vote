using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFPowerVote.Models
{
    public class efusers
    {
        [Key]
        public Guid _id { get; set; }
        [Required]
        public string openid { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public int vote { get; set; }
        public string reason { get; set; }
        public int __v { get; set; }

        public efusers()
        {

        }

        #region 通过openid初始化
        /// <summary>
        /// 通过openid初始化
        /// </summary>
        /// <param name="openid"></param>
        public efusers(string openid)
        {
            this._id = Guid.NewGuid();
            this.openid = openid;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
            this.vote = -1;
            this.reason = "";
            this.__v = 0;
        }
        #endregion
    }

    /// <summary>
    /// 用于展示的，不存数据库中
    /// </summary>
    public class Ticket
    {
        public int vote { get; set; }
        public string reason { get; set; }
    }
}
