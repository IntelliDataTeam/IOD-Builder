# IOD-Builder
Life made easier

<h2>Updates/Latest News</h2>
<h4>10/13/2015</h4>
<ui>
<li>Exploring other libraries to parse excel data</li>
<li>Current library is not sophisticated enough to be of use</li>
<li>EPPlus seems like a good candidate as it is very feature packed</li>
</ui>

<h2>Purpose</h2>
The purpose of this project is to improve the KEMET CCS building process by moving away from excel.<br/>
By removing excel we can improve the <b>performance and organization</b>. Also, it is much more user friendly to recreate <br/>
the macroes into a window application.<br/>
<br/>
<h2>Current Problems</h2>
<ui>
<li>Currently, using a 3rd-party plugin that have very limited reading functionality
<li>Can't get the worksheet name</li>
<li>Still need to decide whether to hardcode the excel formulas0(easier) or make it read from a txt file(harder)</li>
<li><b>Need to create a macro that will print out all of the worksheet's name in order for the config file.</b></li>
</ui>
<br/>
<h2>Proposed Structure</h2>

<h4>Load_Data</h4>
<li>Parsed data from the IOD, storing each worksheet in its own List.</li>
<li>Parsing data will required a good knowledge of the IOD structure so we can cut down on future patches.</li>
<li>Can be very memory intensive as we are storing large amount of data.</li>

<h4>Validation</h4>
<li>Read from the Universe generated csv file line-by-line.</li>
<li>Using logics and data parsed from the IOD, determine if the PN is valid.</li>
<li>Write/Add the valid PN into a csv file, Valid PNs.</li>
<li>Flush the memory once Validation is over to prevent resource hogging.</li>

<h4>Load_Configs</h4>
<li>Read the config files(lookup tables) into memory.</li>
<li>Config files can be in csv since it'll be easier to edit them in excel.</li>
<li>Have to try to condense the number of files down so that less are needed to be open and stored.</li>

<h4>Population</h4>
<li>Read from the Valid PNs file line-by-line</li>
<li>Using logics and the config files to generate value for each columns.</li>
<li>Write the PN into another csv file.</li>
<li>Working line-by-line might be slower, but it cut down on memory hogging, though, could store a certain amount before writing.</li>
