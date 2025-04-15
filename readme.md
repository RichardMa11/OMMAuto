# OMMAuto 解决方案的使用  
1.GitHub 下载最新源码  
2.修改解决方案的平台为X64 （因为SQLite.dll 是64位平台的）  
3.生成，运行解决方案；  
  
# 正在进行中（持续开发中，尚不完善）  
  
新功能开发  
  
# 项目中使用到的技术

NETFramework472  
Panuon.UI.Silver  
log4net  
Newtonsoft.Json   
EasyModbus  
  
开发环境：  
VS2019  
SQLite(64位)  
  
# 功能截图  
主页面  
![image](https://github.com/RichardMa11/CMMAuto/blob/master/%E6%95%88%E6%9E%9C%E5%9B%BE/%E4%B8%BB%E7%95%8C%E9%9D%A2.png)  
辅助界面  
![image](https://github.com/RichardMa11/CMMAuto/blob/master/%E6%95%88%E6%9E%9C%E5%9B%BE/%E5%85%B6%E4%BB%96.png)  
辅助界面  
![image](https://github.com/RichardMa11/CMMAuto/blob/master/%E6%95%88%E6%9E%9C%E5%9B%BE/%E5%85%B6%E4%BB%961.png)  
  
# 更新日志  

250415上传更新:  
  
# 项目业务  
 【收到PLC信号，开始量测程序，结束发送结束信号给PLC】
 1.初始化OMM参数初始化，并退回安全位置；  
 2.启动OMM测试；  
 3.停止OMM测试，并退回安全位置；  
 4.传通给OMM产品ID，通过产品ID调取测试程序；  
 5.读取OMM测试程序所对应的产品ID；  
   
 【给PLC信号】  
 1.本台OMM处于测试忙碌状态（忙碌状态）；  
 2.本台OMM处于测试完成安全位置待上下料状态(待机状态)；  
 3.本台OMM处于异常报警状态；   
 4.本台OMM处于测试中断异常状态；  
 5.本台OMM测试结果，为NG，为PASS；  
 6.本台处于其他未知状态；  
 7.本台OMM安全位置;  
 8.本台OMM测量完成;  
 9.本台OMM工作模式，自动模式/手动模式;  
   
# 项目目标  
实现量测程序的自动化，减少人工干预，实现工厂智能化。  
