var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = $(".mySlides");
    var dots = $(".dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        $(slides[i]).removeClass("d-flex justify-content-center");
        $(slides[i]).addClass("d-none");
    }
    for (i = 0; i < dots.length; i++) {
        $(dots[i]).removeClass("active");
    }
    $(slides[i]).removeClass("d-none");
    $(slides[slideIndex - 1]).addClass("d-flex justify-content-center");
    $(dots[slideIndex - 1]).addClass("active");
}