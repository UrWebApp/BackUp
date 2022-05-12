// 參考 https://stackoverflow.com/questions/49382321/how-to-display-multiple-contents-as-marquee-one-after-another-second-content-sh

window.onload = function () {
    const MarqueeContent = [
        '六月份排程尚餘，歡迎來電來信加Line預約。',
        '疫情影響百工待興，月初前六專案享八五折優惠。',
        '諮詢專線：02-XXXX-XXXXX。',
        '近期工作量滿檔，暫時停止接案，謝謝。'
    ];
    let key = 0;
    const Marquee = $('.marquee');
    Marquee.on('animationstart', () => {
        key = 0;
        Marquee.text(MarqueeContent[key]);
    });
    Marquee.on('animationiteration', () => {
        key++;
        if (typeof MarqueeContent[key] === 'undefined') key = 0;
        Marquee.text(MarqueeContent[key]);
    });
    Marquee.removeClass('paused');
}