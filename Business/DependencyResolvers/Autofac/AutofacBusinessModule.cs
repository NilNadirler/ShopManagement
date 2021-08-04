using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Abstract;
using Core.Adapters;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<LikeOfCommentManager>().As<ILikeOfCommentService>();
            builder.RegisterType<LikeOfPostRepository>().As<ILikeOfPostRepository>();
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<PostImageManager>().As<IPostImageService>();
            builder.RegisterType<PostImageRepository>().As<IPostImageRepository>();
            builder.RegisterType<CloudinaryAdapter>().As<ICloudinaryService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
