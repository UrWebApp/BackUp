// 參考 https://stackoverflow.com/questions/49382321/how-to-display-multiple-contents-as-marquee-one-after-another-second-content-sh

window.onload = function () {
    const MarqueeContent = [
        '六月份排程尚餘，歡迎來電來信加Line預約',
        '疫情影響百工待興，月初前六專案享',
        '諮詢專線：02-XXXX-XXXXX'
    ];
    let key = 0;
    const marquee = $('.marquee');
    marquee.on('animationstart', () => {
        key = 0;
        marquee.text(MarqueeContent[key]);
    });
    marquee.on('animationiteration', () => {
        key++;
        if (typeof MarqueeContent[key] === 'undefined') key = 0;
        marquee.text(MarqueeContent[key]);
    });
    marquee.removeClass('paused');
}