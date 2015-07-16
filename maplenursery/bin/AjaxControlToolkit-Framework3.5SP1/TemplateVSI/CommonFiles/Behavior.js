// README
//
// There are two steps to adding a property:
//
// 1. Create a member variable to store your property
// 2. Add the get_ and set_ accessors for your property
//
// Remember that both are case sensitive!


/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />


Type.registerNamespace('$rootnamespace$');

$rootnamespace$.$safeitemname$ = function(element) {
    $rootnamespace$.$safeitemname$.initializeBase(this, [element]);

    // TODO : (Step 1) Add your property variables here
    this._myPropertyValue = null;
}
$rootnamespace$.$safeitemname$.prototype = {
    initialize : function() {
        $rootnamespace$.$safeitemname$.callBaseMethod(this, 'initialize');

        // TODO: Add your initalization code here
    },

    dispose : function() {
        // TODO: Add your cleanup code here

        $rootnamespace$.$safeitemname$.callBaseMethod(this, 'dispose');
    },

    // TODO: (Step 2) Add your property accessors here
    get_MyProperty : function() {
        return this._myPropertyValue;
    },

    set_MyProperty : function(value) {
        this._myPropertyValue = value;
    }
}
$rootnamespace$.$safeitemname$.registerClass('$rootnamespace$.$safeitemname$', AjaxControlToolkit.BehaviorBase);
