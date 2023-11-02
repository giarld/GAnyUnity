# GAnyUnity
[English](README.md)

为 Unity 提供 GAny 支持, 方便通过 GAny 加载和调用 native 代码, 甚至通过装载 gx-script 来支持 lua 扩展.

## 使用方法
### 编译
新建 build 目录并进入, 执行以下命令(如果没安装cmake, 请先安装, cmake version >= 20):
```shell
cmake -DCMAKE_BUILD_TYPE=Release ..
cmake --build . --target gany-unity
```
复制 `build/bin` 目录下的 `GAnyUnity` 到你的 Unity 项目的 `Assets/Plugins` 下.

## 示例
位置: `examples/TestGAny`, 默认编译配置下, 编译 `gany-unity` 完成后, TestGAny将处于可用状态, 使用 Unity 打开后切换到默认场景并运行便可在 `Unity控制台` 看到测试输出.

## 许可
`GAnyUnity` 根据 [MIT许可证](LICENSE.txt) 授权。
