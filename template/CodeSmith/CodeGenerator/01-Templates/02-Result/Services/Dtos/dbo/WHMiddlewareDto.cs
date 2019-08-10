﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Ding.Applications.Dtos;

namespace GitDC.Service.Dtos.dbo {
    /// <summary>
    /// 网络勾子中转表数据传输对象
    /// </summary>
    public class WHMiddlewareDto : DtoBase {
        /// <summary>
        /// 令牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "令牌输入过长，不能超过100位" )]
        [Column( "Token" )]
        [Display( Name = "令牌" )]
        public string Token { get; set; }
        /// <summary>
        /// 1.腾讯云开发者中心项目
        /// </summary>
        [Column( "Source" )]
        [Display( Name = "1.腾讯云开发者中心项目" )]
        public short? Source { get; set; }
        /// <summary>
        /// 1.钉钉
        /// </summary>
        [Column( "Push" )]
        [Display( Name = "1.钉钉" )]
        public short? Push { get; set; }
        /// <summary>
        /// 推送Url
        /// </summary>
        [StringLength( 250, ErrorMessage = "推送Url输入过长，不能超过250位" )]
        [Column( "PushUrl" )]
        [Display( Name = "推送Url" )]
        public string PushUrl { get; set; }
        /// <summary>
        /// 推送令牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "推送令牌输入过长，不能超过100位" )]
        [Column( "PushToken" )]
        [Display( Name = "推送令牌" )]
        public string PushToken { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column( "CreationTime" )]
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Column( "CreatId" )]
        [Display( Name = "创建人编号" )]
        public int? CreatId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column( "LastModifiTime" )]
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModifiTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Column( "LastModifiId" )]
        [Display( Name = "最后修改人编号" )]
        public int? LastModifiId { get; set; }
        /// <summary>
        /// 软删除，数据不会被物理删除
        /// </summary>
        [Column( "IsDeleted" )]
        [Display( Name = "软删除，数据不会被物理删除" )]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 处理并发问题
        /// </summary>
        [Column( "Version" )]
        [Display( Name = "处理并发问题" )]
        public Byte[] Version { get; set; }
    }
}