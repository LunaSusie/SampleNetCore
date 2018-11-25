
# 项目文件csproj简单介绍 
TargetFramework 目标框架
PackgeReference 应用包
# 启动
启动顺序：program->main->startup

默认启动参考github仓库：aspnet/MetaPackges/src/Microsoft.AspNetCoe/WebHost.cs

starup：先执行configureServices方法，在执行Configure方法

# 依赖注入生命周期

* Transient:每次创建新实例
* Scoped:每次web请求创建实例
* Singleton:单例