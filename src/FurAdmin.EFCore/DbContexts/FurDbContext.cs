using System;
using System.Linq;
using Fur;
using Fur.DatabaseAccessor;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FurAdmin.EFCore
{
    [AppDbContext("Sqlite3ConnectionString")]
    public class FurDbContext : AppDbContext<FurDbContext>
    {
        public FurDbContext(DbContextOptions<FurDbContext> options) : base(options)
        {
        }

        #region 审计日志，Audit为实体，要自行创建
        ///// <summary>
        ///// 重写保存之前事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected override void SavingChangesEvent(object sender, SavingChangesEventArgs e)
        //{
        //    // 获取当前事件对应上下文
        //    var dbContext = sender as FurDbContext;
        //    // 强制重新检查一边实体更改信息
        //    dbContext.ChangeTracker.DetectChanges();
        //    // 获取所有更改，删除，新增的实体，但排除审计实体（避免死循环）
        //    var entities = dbContext.ChangeTracker.Entries()
        //        .Where(u => u.Entity.GetType() != typeof(Audit) && (u.State == EntityState.Modified || u.State == EntityState.Deleted || u.State == EntityState.Added));
        //    // 通过请求中获取当前操作人
        //    var userId = App.GetService<IHttpContextAccessor>().HttpContext.Items["UserId"];
        //    // 获取所有已更改的实体
        //    foreach (var entity in entities)
        //    {
        //        // 获取实体类型
        //        var entityType = entity.Entity.GetType();
        //        // 获取所有实体有效属性，排除 [NotMapper] 属性
        //        var props = entity.OriginalValues.Properties;
        //        // 获取实体当前（现在）的值
        //        var currentValues = entity.CurrentValues;
        //        // 获取数据库中实体的值
        //        var databaseValues = entity.GetDatabaseValues();
        //        // 遍历所有属性
        //        foreach (var prop in props)
        //        {
        //            // 获取属性名
        //            var propName = prop.Name;
        //            // 获取现在的实体值
        //            var newValue = currentValues[propName];
        //            object oldValue = null;
        //            // 如果是新增数据，则 databaseValues 为空，所以需要判断一下
        //            if (databaseValues != null)
        //            {
        //                oldValue = databaseValues[propName];
        //            }
        //            // 插入审计日志表
        //            dbContext.Audits.Add(new Audit
        //            {
        //                Table = entityType.Name,    // 表名
        //                Column = propName,  // 更新的列
        //                NewValue = newValue,    // 新值
        //                OldValue = oldValue,    // 旧值
        //                CreatedTime = DateTime.Now, // 操作时间
        //                UserId = userId,    // 操作人
        //                Operate = entity.State.ToString()  // 操作方式：新增、更新、删除
        //            });
        //        }
        //    }
        //} 
        #endregion
    }
}