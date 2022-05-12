// 參考 https://stackoverflow.com/questions/49382321/how-to-display-multiple-contents-as-marquee-one-after-another-second-content-sh

//list of slides to be shown
const MarqueeContent = [
    'first slide',
    'second slide',
    'third slide'
];

let key = 0;
const marquee = $('.marquee');
marquee.on('animationstart', () => {
    key = 0;
    marquee.text(content[key]);
});
marquee.on('animationiteration', () => {
    key++;
    if(typeof content[key] === 'undefined') key = 0;
    marquee.text(content[key]);
});
marquee.removeClass('paused');