# CustomThemeDemo 客製化主題演示

Some basic skills to custom theme.

## Involve knowledge points 涉及知識點

1. [首先你必須要了解 Hexo 基礎使用](https://hexo.io/zh-tw/docs/themes)
   1. _config.yml 配置檔類似 CSS 權重，外層 _config.yml > 外層 _config.[主題名].yml > 主題 Theme 層 _config.yml
   2. 應用程式資料。EJS, Stylus 和 Markdown renderer 已預設安裝，所以才能解析 .ejs 副檔名檔案
   3. Hexo 會根據 Scaffold 資料夾內的版型來以 Source 資料夾內的內容 Build 靜態檔案 (Html js css) 至 Public 資料夾
   4. 檔案 / 資料夾名稱開頭為 _ (底線) 和隱藏檔案會被忽略，除了 _posts 資料夾以外，其他檔案會被拷貝過去。
   5. permalink 感覺是最重要的參數，可以影響生成的資料夾結構，影響 SEO
2. [Mike Dane 有基礎的教學影片](https://www.youtube.com/watch?v=Kt7u5kr_P5o&list=PLLAZ4kZ9dFpOMJR6D25ishrSedvsguVSm&ab_channel=MikeDane)
3. [~~內建 Nunjucks 模板引擎可以透過中文快速學習(相較於ejs複雜棄用)~~](https://nunjucks.bootcss.com/)
4. [ejs 中文網站快速學習](https://ejs.bootcss.com/#promo)
   > <% '脚本' 标签，用于流程控制，无输出。
   >
   > <%_ 删除其前面的空格符
   >
   > <%= 输出数据到模板（输出是转义 HTML 标签）
   >
   > <%- 输出非转义的数据到模板
   >
   > <%# 注释标签，不执行、不输出内容
   >
   > <%% 输出字符串 '<%'
   >
   > %> 一般结束标签
   >
   > -%> 删除紧随其后的换行符
   >
   > _%> 将结束标签后面的空格符删除
5. [其實之前有個專案已研究過一些簡易 Demo 只是沒註解](https://github.com/Cara-Drumstick-Bug/Research-Co-writing/tree/master/Research-Hellow-Hexo)
5. [hexo-theme-landscape](https://github.com/hexojs/hexo-theme-landscape)
6. [Hexo 新增 Sass](https://jas0nhuang.github.io/2020/05/06/hexo-sass/)
