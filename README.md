GitDC是基于.Net Core 2.2的Git Server服务端程序。

底层框架：[DC.FrameWork](https://gitee.com/xingchensoft/DC.Framework/tree/develop)
后面前端会考虑使用Blazor框架： [DC.Blazor](https://gitee.com/xingchensoft/DC.Blazor)

感谢：
- [linezero/GitServer](https://github.com/linezero/GitServer)
- [Aimeast/GitCandy](https://github.com/Aimeast/GitCandy)

QQ群：774046050

 **如果我的代码对您有用，请打赏一点吧，谢谢，您的打赏是我的动力** 

 **源码仅用于交流学习，开源协议为[GPL-3.0](https://gitee.com/kwwwvagaa/net_winform_custom_control/blob/master/LICENSE)，如商业使用请进群联系群主授权** 

下载之后运行dotnet watch run可直接本地运行。数据库为mysql，默认有连接远程服务器测试数据库。
本地数据库脚本目录：GitDC.Data/DbScripts/Mysql。 后续会持续支持Sqlite/Oracle/Pgsql/SqlServer

运行之后的演示地址：http://localhost:7070  账号：admin   密码： admin

已实现功能：

1. 用户注册
2. 用户登录
3. 创建仓库
4. 上传和拉取源码
5. 仓库项目资源列表展示
6. 腾讯开发者和禅道webHook转发钉钉机器人（目前只实现了手动在数据库里配置）。

腾讯开发者中心和禅道WebHook转发：

![腾讯开发者中心和禅道WebHook转发](https://images.gitee.com/uploads/images/2019/0824/193040_8a971469_130171.png "33FDE26F-C284-440d-8407-F787B20ED556.png")

![注册](https://images.gitee.com/uploads/images/2019/0815/212129_dfe17ade_130171.png "5972F9CE-38AE-45f7-B84B-0F852FECCD61.png")
![登录](https://images.gitee.com/uploads/images/2019/0815/212158_13664b4e_130171.png "259BE4A4-4BB4-47ab-82E0-28675B4C3E30.png")
![仓库列表](https://images.gitee.com/uploads/images/2019/0817/235323_bb32fce7_130171.jpeg "360截图20190817235254075.jpg")