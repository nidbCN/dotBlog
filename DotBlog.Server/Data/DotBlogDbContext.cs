﻿using Microsoft.EntityFrameworkCore;

using DotBlog.Server.Entities;

namespace DotBlog.Server.Data
{
    public class DotBlogDbContext : DbContext
    {
        public DotBlogDbContext(DbContextOptions<DotBlogDbContext> options) : base(options)
        {
            // 构造函数，将options传给父类的构造函数
        }

        /// <summary>
        /// 文章表
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// 回复表
        /// </summary>
        public DbSet<Reply> Replies { get; set; }

        // 重写父类方法设置数据库
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var articleConf = modelBuilder.Entity<Article>();
            var replyConf = modelBuilder.Entity<Reply>();

            // 设置对应关系
            replyConf
                .HasOne(it => it.Article)
                .WithMany(it => it.Replies)
                .HasForeignKey(it => it.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // 设置键和索引
            replyConf.HasKey(it => it.ReplyId);
            replyConf.HasIndex(it => it.ReplyId);
            articleConf.HasKey(it => it.ArticleId);
            articleConf.HasIndex(it => it.ArticleId);
        }
    }
}
