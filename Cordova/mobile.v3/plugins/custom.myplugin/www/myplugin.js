module.exports = {
  run : function () {
    alert('lancement du plugin');
    cordova.exec(
      function(okresult) {
        alert(okresult);
      },
      function(nokresult) {
        alert('mon plugin');
      },
      "MyPlugin", "Method", "hello" );
  }
}