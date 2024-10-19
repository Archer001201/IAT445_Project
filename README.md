# IAT445_Project

### 如何在Unity Editor中加载场景
1. 在<strong>Assets/Scenes</strong>文件夹中找到<strong>0_PersistentScene</strong>，双击进入该场景。<img width="583" alt="image" src="https://github.com/user-attachments/assets/5119d3ab-c8dc-4756-b83b-675b10193926">
2. 点击Hierachy面板中的<strong>System/Game Manager</strong>，勾选<strong>Play In Editor</strong>的选项。<img width="821" alt="image" src="https://github.com/user-attachments/assets/b5a3f05c-bc86-47e9-8831-faf0ff4dbc6c">
3. 在<strong>Assets/Scenes</strong>文件夹中将其他需要的场景拖拽到Hierarchy面板中。<img width="1233" alt="image" src="https://github.com/user-attachments/assets/83d1ec91-a020-45ee-a64a-309c07af454d">
4. 如果要从当前的游戏画面中移除或者卸载场景，点击对应场景旁边的三个点，选择<strong>Unload Scene</strong>或者<strong>Remove Scene</strong><img width="317" alt="image" src="https://github.com/user-attachments/assets/13a40ba3-a12d-490f-ad6e-76cce13b48e5">

### 如何在Unity Editor中使用Simulator测试游戏
1. 激活Hierachy面板中的<strong>XR Components/XR Device Simulator</strong>。<img width="960" alt="image" src="https://github.com/user-attachments/assets/a892d268-3183-43c5-b3d7-55a314a445cc">
2. 在XR Device Simulator的Inspector面板中，如果勾线<strong>Allow Attach</strong>，相机和相册则会跟随在玩家身后；如果取消勾选<strong>Allow Attach</strong>，相机和相册则会停留在场景中。使用Simulator进行测试时建议取消勾选该<strong>Allow Attach</strong>，可以更方便抓取。<img width="484" alt="image" src="https://github.com/user-attachments/assets/86097133-d4d0-4ede-84c9-bd7e197b39d3">






