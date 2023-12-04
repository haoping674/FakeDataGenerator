# Fake Data Generator

## 題目

写一只假资料产生器, 对 member 塞值, 以及做假交易
说明:
1.  a. 模拟客户注册, 如果有填入 recommend, 且值等于其他会员的 invitation_code, 则 agent_fk 值设置为该会员的 pk, 否则 agent_fk = 0

    b. 客户注册成功, 即给他一个独立的 invitation_code, 长度为七码 
    > 提示: 先建好1000笔客户资料, 并且给完毕 invitation_code, 再开始模拟推荐行为，系统较容易写	  

    c. 将客户注册时间设置成一整年, 随机都有资料.
    乱数塞 1000笔
    
2. 随机建立 2500 笔交易, 不需要所有的客户都有交易, 有些客户没有交易, 将交易结果
    存入 borrow_fee, 交易金额为随机即可.
    a. 所有的交易时间, 一定都是在客户注册后才会发生
    b. 客户第二次以后交易,设置 borrow_fee.type = 2, 
    交易期限 18个月, 随机都有资料.

## 成果畫面

![](images/1.png)
![](images/2.png)