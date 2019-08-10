﻿using Ding;
using GitDC.Domain.Models;
using Ding.Maps;

namespace GitDC.Data.Pos.dbo.Extensions {
    /// <summary>
    /// 网络勾子推送内容日志持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为网络勾子推送内容日志实体
        /// </summary>
        /// <param name="po">网络勾子推送内容日志持久化对象</param>
        public static WHLogs ToEntity( this WHLogsPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new WHLogs( po.Id ) );
        }
        
        /// <summary>
        /// 转换为网络勾子推送内容日志实体
        /// </summary>
        /// <param name="po">网络勾子推送内容日志持久化对象</param>
        private static WHLogs ToEntity2( this WHLogsPo po ) {
            if( po == null )
                return null;
            return new WHLogs( po.Id ) {
                WHTypes = po.WHTypes,
                Content = po.Content,
                CreatId = po.CreatId,
                CreationTime = po.CreationTime,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为网络勾子推送内容日志持久化对象
        /// </summary>
        /// <param name="entity">网络勾子推送内容日志实体</param>
        public static WHLogsPo ToPo(this WHLogs entity) {
            if( entity == null )
                return null;
            return entity.MapTo<WHLogsPo>();
        }

        /// <summary>
        /// 转换为网络勾子推送内容日志持久化对象
        /// </summary>
        /// <param name="entity">网络勾子推送内容日志实体</param>
        private static WHLogsPo ToPo2( this WHLogs entity ) {
            if( entity == null )
                return null;
            return new WHLogsPo {
                Id = entity.Id,
                WHTypes = entity.WHTypes,
                Content = entity.Content,
                CreatId = entity.CreatId,
                CreationTime = entity.CreationTime,
                IsDeleted = entity.IsDeleted,
                Version = entity.Version,
            };
        }
    }
}
