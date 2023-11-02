# GAnyUnity
[中文](README-zh.md)

Provide GAny support for Unity, making it easy to load and call native code through GAny, and even support Lua extensions by loading gx script.

## Usage
### Build
Create a new build directory and enter it. Execute the following command (if cmake is not installed, please install it first, cmake version>=20):
```shell
cmake -DCMAKE_BUILD_TYPE=Release ..
cmake --build . --target gany-unity
```
Copy `gany-unity` from the `build/bin` directory to the `Assets/Plugins` folder of your Unity project.

## Example
Path: `examples/TestGAny`. In the default compilation configuration, after compiling `gany-unity`, TestGANy will be available. After opening it with Unity, switch to the default scenario and run it to see the test output in the `Unity console`.

## License
`GAnyUnity` is licensed under the [MIT License](LICENSE.txt).
