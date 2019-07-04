using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft;

namespace BarcodeFramework
{
  class DeviceInfo
  {
    const Int32 METHOD_BUFFERED = 0;
    const Int32 FILE_ANY_ACCESS = 0;
    const Int32 FILE_DEVICE_HAL = 0x00000101;

    public string DeviceID { get { return GetDeviceID(); } }
    public string HostName { 
      get 
      {
        const string userRoot = "HKEY_LOCAL_MACHINE";
        const string subkey = "Ident";
        const string keyName = userRoot + "\\" + subkey;
        try
        {
          return (string)Microsoft.Win32.Registry.GetValue(keyName, "Name", "");
        }
        catch (Exception)
        {
          return "";
        }
      } 
    }

    const Int32 IOCTL_HAL_GET_DEVICEID = ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14) | ((21) << 2) | (METHOD_BUFFERED);
    [DllImport("coredll.dll")]    
    private static extern bool KernelIoControl(Int32 IoControlCode, IntPtr InputBuffer, Int32 InputBufferSize, byte[] OutputBuffer, Int32 OutputBufferSize, ref Int32 BytesReturned);
    private static string GetDeviceID()
    {
      // Reference: http://msdn.microsoft.com/en-us/library/aa446562.aspx
      byte[] data = new byte[256];
      Int32 OutputBufferSize, BytesReturned;
      OutputBufferSize = data.Length;
      BytesReturned = 0;
      // Call KernelIoControl passing the previously defined IOCTL_HAL_GET_DEVICEID parameter
      // We don’t need to pass any input buffers to this call
      // so InputBuffer and InputBufferSize are set to their null values
      bool retVal = KernelIoControl(IOCTL_HAL_GET_DEVICEID, IntPtr.Zero, 0, data, OutputBufferSize, ref BytesReturned);
      // If the request failed, exit the method now
      if (retVal)
      {
        // Examine the OutputBuffer byte array to find the start of the 
        // Preset ID and Platform ID, as well as the size of the PlatformID. 
        // PresetIDOffset – The number of bytes the preset ID is offset from the beginning of the structure
        // PlatformIDOffset - The number of bytes the platform ID is offset from the beginning of the structure
        // PlatformIDSize - The number of bytes used to store the platform ID
        // Use BitConverter.ToInt32() to convert from byte[] to int
        Int32 PresetIDOffset = BitConverter.ToInt32(data, 4);
        Int32 PlatformIDOffset = BitConverter.ToInt32(data, 0xc);
        Int32 PlatformIDSize = BitConverter.ToInt32(data, 0x10);

        // Convert the Preset ID segments into a string so they can be 
        // displayed easily.
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("{0:X8}-{1:X4}-{2:X4}-{3:X4}-",
             BitConverter.ToInt32(data, PresetIDOffset),
             BitConverter.ToInt16(data, PresetIDOffset + 4),
             BitConverter.ToInt16(data, PresetIDOffset + 6),
             BitConverter.ToInt16(data, PresetIDOffset + 8)));

        // Break the Platform ID down into 2-digit hexadecimal numbers
        // and append them to the Preset ID. This will result in a 
        // string-formatted Device ID
        for (int i = PlatformIDOffset; i < PlatformIDOffset + PlatformIDSize; i++)
        {
          sb.Append(String.Format("{0:X2}", data[i]));
        }
        // return the Device ID string
        return sb.ToString();
      }
      return null;
    }
  }
}
