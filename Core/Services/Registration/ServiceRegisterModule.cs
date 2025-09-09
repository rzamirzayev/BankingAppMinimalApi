﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Registration
{
    public class ServiceRegisterModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var types = GetType().Assembly.GetTypes()
                        .Where(m => m.IsClass)
                        .Select(m => new
                        {
                            Type = m,
                            IsSingleton = m.IsDefined(typeof(SingletonLifeTimeAttribute))
                        });


            builder.RegisterTypes(types.Where(m => m.IsSingleton).Select(m => m.Type).ToArray())
               .AsImplementedInterfaces()
               .SingleInstance();

            builder.RegisterTypes(types.Where(m => m.IsSingleton == false).Select(m => m.Type).ToArray())
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();


        }
    }
}
