# SPX-ImageCreationTool
<b>Cobs Surface Pro X Image Creation Tool</b>

<p>This tool is still in development and as of now, does not work and is in design stages</p>

<p>This is a tool written in VB.NET (targetting .net 4.7.2) that allows users to use clean images of Windows from official sources, such as VLSC, the Microsoft Downloads website, UUPDump or existing ARM64 installation media with the Pro X. By default, attempting to load one will result in the keyboard, touchscreen and any peripherals to be non-functional due to lack of drivers</p>
<h3>Why?</h3>
<p>Personally, I prefer clean images of Windows, or alternative versions, such as a clean install of Insider. This is also useful for enterprise scenarios where deployment is preferred without having to use Backup Recovery Media that's on a previous version of Windows, then having to upgrade to 11. This wastes time which the tool aims to solve'</p>
<h3>How does it work?</h3>
<p>After selecting the requried files, the tool will either export drivers from an existing recovery image or alternatively use an existing ZIP file with the drivers exported (you can use dism to export online drivers form a functioning Pro X.) and then inject them into the required files, these being, both index of boot.wim, and install.wim (only one index)</p>
<p>It's recommended to use UUPDump so you end up with an ISO file that only contains one Index. The tool right now will only update one index.</p>

<h3>ZIP File format (if you've exported drivers)</h3>
<p>Root ZIP folder</p>
<p>-boot (dir)</p>
<p>--driverX (dir)</p>
<p>---driver files (inf files, sys, etc)</p>
<p>-install (dir)</p>
<p>--driverX (dir)</p>
<p>---driver files (inf files, sys, etc)</p>

<h3>Credits</h3>
<p>Bwenfwake - Editing my horrific photo of my Pro X and making it look nice for the installer <3</p>
