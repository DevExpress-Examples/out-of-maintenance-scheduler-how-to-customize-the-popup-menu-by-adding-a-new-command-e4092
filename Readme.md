<!-- default file list -->
*Files to look at*:

* [SchedulerPartial.cshtml](./CS/Scheduler.PopupMenuShowing/Views/Home/SchedulerPartial.cshtml)
<!-- default file list end -->
# Scheduler - How to customize the popup menu by adding a new command
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4092/)**
<!-- run online end -->


<p>This example illustrates the technique used to customize the popup menu of the SchedulerControl. It allows you to insert a new command, change the command bound to an existing menu item or remove an unnecessary item from the popup menu.</p><p>In this project the <strong>PopupMenuShowing </strong>event is handled to add a new item named <i>ShowResources</i><strong> </strong>and to specify a client-side handler for the menu click event. Clicking menu item invokes a custom JavaScript function if the name of an  item being clicked is <i>ShowResources</i>. Otherwise the client Scheduler control creates and executes a  callback command using item name as a parameter.<br />
For more information on commands review the article <a href="http://documentation.devexpress.com/#AspNet/CustomDocument5462"><u>Callback Commands</u></a>.</p>

<br/>


