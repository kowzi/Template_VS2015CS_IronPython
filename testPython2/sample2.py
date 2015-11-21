#-*- coding: utf-8 -*-
#----- Importing for VS2015 C# -----
import sys
sys.path.append("C:\Program Files (x86)\IronPython 2.7")
sys.path.append("C:\Program Files (x86)\IronPython 2.7\DLLs")
sys.path.append("C:\Program Files (x86)\IronPython 2.7\Lib")
sys.path.append("C:\Program Files (x86)\IronPython 2.7\Lib\site-packages")
#-----------------------------------
 
import datetime
import locale


strDateToday = datetime.datetime.today()
strReturn = strFromCS + strDateToday.strftime("%Y%m%d %H:%M:%S")