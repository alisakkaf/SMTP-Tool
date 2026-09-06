# Contributing to SMTP Tool

Thank you for your interest in contributing to **SMTP Tool**! We welcome bug reports, feature proposals, and pull requests from developers worldwide.

---

## Development Setup

### Prerequisites

- **Windows 7 SP1, 8, 8.1, 10, or 11**
- **Visual Studio 2019 or Visual Studio 2022** (.NET desktop development workload)
- **.NET Framework 4.8 Developer Pack**

### Building from Source

1. Clone the repository:
   ```bash
   git clone https://github.com/alisakkaf/SMTP-Tool.git
   cd SMTP-Tool
   ```
2. Open `source/SMTPtool.sln` in Visual Studio or build via MSBuild:
   ```powershell
   msbuild source/SMTPtool.sln /p:Configuration=Release
   ```
3. The compiled standalone executable will be located at:
   `source/SMTPtool/bin/Release/SMTPTool.exe`

---

## Contribution Workflow

1. **Fork the Repository**: Create your own feature branch:
   ```bash
   git checkout -b feature/awesome-enhancement
   ```
2. **Follow Coding Standards**:
   - Write clean, idiomatic C# code.
   - Maintain Title Case formatting for all user-facing labels and buttons.
   - Ensure async / multi-threaded socket operations never freeze the UI thread.
   - Ensure backward compatibility with Windows 7 through 11.
3. **Test Your Changes**: Verify that the solution compiles with 0 errors and 0 warnings.
4. **Submit a Pull Request**: Provide a concise description of what was changed and why.

---

## Code of Conduct

Please review our [Code of Conduct](CODE_OF_CONDUCT.md) before participating in this project.
