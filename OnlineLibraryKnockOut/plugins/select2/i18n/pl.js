/*! Select2 4.0.1 | https://github.com/select2/select2/blob/master/LICENSE.md */

(function() {
 if (jQuery && jQuery.fn && jQuery.fn.select2 && jQuery.fn.select2.amd) var e = jQuery.fn.select2.amd;
 return e.define("select2/i18n/pl", [], function() {
  var e = ["znak", "znaki", "znaków"],
   t = ["element", "elementy", "elementów"],
   n = function(t, n) {
    if (t === 1) return n[0];
    if (t > 1 && t <= 4) return n[1];
    if (t >= 5) return n[2]
   };
  return {
   errorLoading: function() {
       return "Could not load results."
   },
   inputTooLong: function(t) {
    var r = t.input.length - t.maximum;
    return "Delete " + r + " " + n(r, e)
   },
   inputTooShort: function(t) {
    var r = t.minimum - t.input.length;
    return "Give at least " + r + " " + n(r, e)
   },
   loadingMore: function() {
    return "Loading ..."
   },
   maximumSelected: function(e) {
       return "You can tick only" + e.maximum + " " + n(e.maximum, t)
   },
   noResults: function() {
       return "No results"
   },
   searching: function() {
       return "Searching ..."
   }
  }
 }), {
  define: e.define,
  require: e.require
 }
})();