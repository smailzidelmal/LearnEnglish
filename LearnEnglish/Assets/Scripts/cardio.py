import sys, os
sys.path
import time
import numpy as np
import matplotlib.pyplot as plt

#from bitalino import BITalino
import bitalino as bt

devices = {
    "HeartBIT1": "20:17:09:18:59:61", # Red
    "HeartBIT2": "20:19:07:00:80:B3",
    "NeuroBIT1": "20:18:08:08:01:88", # Blue
    "NeuroBIT2": "00:21:06:BE:16:15",
    "MuscleBIT1": "20:18:08:08:02:30", # Green
    "MuscleBIT2": "20:19:07:00:7F:7A",
    "PsychoBIT1": "20:18:05:28:47:03", # White
    "PsychoBIT2": "00:21:06:BE:15:4F"
}

dictChannels = {"A1":5, "A2":6, "A3":7, "A4":8, "A5":9, "A6":10}

# This example will collect data for 10 sec.
running_time = 10
    
batteryThreshold = 30
acqChannels = [0, 1, 2, 3, 4, 5]
samplingRate = 1000
nSamples = 10
digitalOutput = [1,1]


# Choose a device
macAddress = devices["PsychoBIT2"]
# Connect to BITalino
device = bt.BITalino(macAddress)

# Set battery threshold
device.battery(batteryThreshold)

# Read BITalino version
print(device.version())
    
# Start Acquisition
device.start(samplingRate, acqChannels)
s = 500
data = []
def run_cardio():
    start = time.time()
    end = time.time()
    count = 0
    isbip = False

    file = "cardio.txt"

    while True: #(end - start) < running_time:
        # Read samples
        
        dataRead = device.read(1)
        #print(dataRead)
        if dataRead[0][dictChannels['A1']] > s:
            if not isbip:
                isbip = True
                count +=1
        else:
            isbip = False
        if (end - start) > 10:
            with open(os.path.dirname(__file__) + "/" + file, 'w') as f:
                print("cardio =", count * 6)
                f.write(str(count * 6))
            count = 0
            start = time.time()
        data.append(dataRead)
        end = time.time()

    # Turn BITalino led on
    device.trigger(digitalOutput)
        
    # Stop acquisition
    device.stop()
        
    # Close connection
    device.close()