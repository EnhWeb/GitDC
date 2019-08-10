﻿using Ding;
using GitDC.Domain.Models;
using Ding.Maps;

namespace GitDC.Data.Pos.dbo.Extensions {
    /// <summary>
    /// 用户名持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为用户名实体
        /// </summary>
        /// <param name="po">用户名持久化对象</param>
        public static DCUsers ToEntity( this DCUsersPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new DCUsers( po.Id ) );
        }
        
        /// <summary>
        /// 转换为用户名实体
        /// </summary>
        /// <param name="po">用户名持久化对象</param>
        private static DCUsers ToEntity2( this DCUsersPo po ) {
            if( po == null )
                return null;
            return new DCUsers( po.Id ) {
                Name = po.Name,
                NickName = po.NickName,
                Email = po.Email,
                PasswordVersion = po.PasswordVersion,
                Password = po.Password,
                Salt = po.Salt,
                Description = po.Description,
                IsSystemAdministrator = po.IsSystemAdministrator,
                CreationTime = po.CreationTime,
                CreatId = po.CreatId,
                LastModifiTime = po.LastModifiTime,
                LastModifiId = po.LastModifiId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为用户名持久化对象
        /// </summary>
        /// <param name="entity">用户名实体</param>
        public static DCUsersPo ToPo(this DCUsers entity) {
            if( entity == null )
                return null;
            return entity.MapTo<DCUsersPo>();
        }

        /// <summary>
        /// 转换为用户名持久化对象
        /// </summary>
        /// <param name="entity">用户名实体</param>
        private static DCUsersPo ToPo2( this DCUsers entity ) {
            if( entity == null )
                return null;
            return new DCUsersPo {
                Id = entity.Id,
                Name = entity.Name,
                NickName = entity.NickName,
                Email = entity.Email,
                PasswordVersion = entity.PasswordVersion,
                Password = entity.Password,
                Salt = entity.Salt,
                Description = entity.Description,
                IsSystemAdministrator = entity.IsSystemAdministrator,
                CreationTime = entity.CreationTime,
                CreatId = entity.CreatId,
                LastModifiTime = entity.LastModifiTime,
                LastModifiId = entity.LastModifiId,
                IsDeleted = entity.IsDeleted,
                Version = entity.Version,
            };
        }
    }
}
