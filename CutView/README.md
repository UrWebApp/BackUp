# CutView 切版

Convert the screen to html in consideration of modularization.

## Step 步驟

1. 分類有哪幾種重複的元件
   1. Menu
   2. Sidebar
   3. Footer
2. 考量手機版
3. 訂定命名法規則，用以區別自訂與引用參數 ex. bs4 為小寫
   1. 看到網路有人說 `類的命名使用大駝峰，方法和變數的命名使用小駝峰，常量全大寫，並且使用下劃線來分割單詞`
   2. 目前公司則會冠名在變數前方 ex. EnumActionType
   3. 目前我們決定全部大駝峰
4. [Swiper 基本原理參考](https://ithelp.ithome.com.tw/articles/10197850)
   1. 原理是靠丟進去 API 的 class 字段去控制 DOM
   2. [應該看 Swiper 中文站的範例就夠實作了](https://www.swiper.com.cn/api/start/new.html)