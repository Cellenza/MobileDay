module.exports = {
  run : function () {
    var donothing = function() {};
    cordova.exec(donothing, donothing,
      "Call4Coffee", "Do");
  }
}