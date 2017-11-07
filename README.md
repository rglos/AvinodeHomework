# Avinode Homework

Parses an XML file like so:

```
<menu>
	<item>
		<displayName>Home</displayName>
		<path value="/Default.aspx"/>
	</item>
	<item>
		<displayName>Trips</displayName>
		<path value="/Requests/Quotes/CreateQuote.aspx"/>
		<subMenu>
			<item>
				<displayName>Create Quote</displayName>
				<path value="/Requests/Quotes/CreateQuote.aspx"/>
			</item>
			<item>
				<displayName>Open Quotes</displayName>
				<path value="/Requests/OpenQuotes.aspx"/>
			</item>
			<item superOverride="true">
				<displayName>Scheduled Trips</displayName>
				<path value="/Requests/Trips/ScheduledTrips.aspx"/>
			</item>
		</subMenu>
	</item>
	<item>
		<displayName>Company</displayName>
		<path value="/mvc/company/view" />
		<subMenu>
			<item>
				<displayName>Customers</displayName>
				<path value="/customers/customers.aspx"/>
			</item>
			<item>
				<displayName>Pilots</displayName>
				<path value="/pilots/pilots.aspx"/>
			</item>
			<item>
				<displayName>Aircraft</displayName>
				<path value="/aircraft/Aircraft.aspx"/>
			</item>
		</subMenu>
	</item>
</menu> 
```

Expects 2 arguments, first is the path to the file, second is the active path to match.  Here's an example running it from the `.\src\ConsoleApp\bin\Debug` directory.

```
.\ConsoleApp.exe "..\..\..\Wyvern Menu.txt" "/TWR/AircraftSearch.aspx"
```

Returns output to the console showing the displayName, path, and optionally an ACTIVE notification for the item and it's parent items.

```
Home, /mvc/wyvern/home ACTIVE
    News, /mvc/wyvern/home/news
    Directory, /Directory/Directory.aspx ACTIVE
        Favorites, /TWR/Directory.aspx
        Search Aircraft, /TWR/AircraftSearch.aspx ACTIVE
PASS, /PASS/GeneratePASS.aspx
    Create New, /PASS/GeneratePASS.aspx
    Sent Requests, /PASS/YourPASSReports.aspx
    Received Requests, /PASS/Pending/PendingRequests.aspx
Company, /mvc/company/view
    Users, /mvc/account/list
    Aircraft, /aircraft/fleet.aspx
    Insurance, /insurance/policies.aspx
    Certificate, /Certificates/Certificates.aspx
```