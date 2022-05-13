
export default function () {
    // Initialize Swiper
    let swiper = new Swiper(".mySwiper", {
        loop: true,
        // autoplay: {
        //   delay: 20000,
        //   disableOnInteraction: false,
        // },
        speed: 1000,
        preloadImages: true,
        updateOnImagesReady: true,
        parallax: true,
        // navigation: {
        //     nextEl: ".swiper-button-next",
        //     prevEl: ".swiper-button-prev",
        // },
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
            bulletClass: 'swiper-pagination-item',
            bulletActiveClass: 'active',
            clickableClass: 'swiper-pagination-clickable',
            modifierClass: 'swiper-pagination-',
            renderBullet: function (index, className) {

                var slideIndex = index,
                    number = (index <= 10) ? '0' + (slideIndex + 1) : (slideIndex + 1);

                var paginationItem = '<span class="swiper-pagination-item">';
                paginationItem += '<span class="pagination-number">' + number + '</span>';
                paginationItem = (index <= 10) ? paginationItem + '<span class="pagination-separator"><span class="pagination-separator-loader"></span></span>' : paginationItem;
                paginationItem += '</span>';

                return paginationItem;

            },
        },
    });
}