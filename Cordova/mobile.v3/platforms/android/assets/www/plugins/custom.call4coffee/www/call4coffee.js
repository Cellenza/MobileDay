cordova.define("custom.call4coffee.call4coffee", function(require, exports, module) { module.exports = {
  run : function () {
    var donothing = function() {};
    cordova.exec(donothing, donothing,
      "Call4Coffee", "Do");
  }
}
});
