# Receipt Scanning System


The purpose of the Receipt Scanning System is to parse and process OCR data from receipt images stored in JSON format. The objective of this project is to accurately extract information from the JSON data and save it in a format that closely resembles the original text found on the receipts.
## Requirements

- .NET 6.0 SDK

## Installation and Usage

1. Clone the project and navigate to the program directory.

   ```bash
    git clone https://github.com/sametkayik/ReceiptScanningSystem.git
    cd ReceiptScanningSystem/ReceiptScanningSystem
    ```
 3. Install the Newtonsoft.Json package.

    ```bash
    dotnet add package Newtonsoft.Json
    ```
4. Run the program.

    ```bash
    dotnet run Program.cs
    ```
    
The `response.json` and `output.json` files can be found in the directory: `ReceiptScanningSystem\ReceiptScanningSystem\bin\Debug\net6.0`.

### Output
![image](https://github.com/sametkayik/ReceiptScanningSystem/assets/53970699/e6abc13b-c5cb-488a-bc1d-b8f0948f6cec)





