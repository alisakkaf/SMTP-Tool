# Changelog

All notable changes to the **SMTP Tool** project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.0] - 2026-09-06

### Major Project Reboot & Modernization by AliSakkaF

#### Added
- **Modern Windows Forms UI**: Complete interface redesign featuring clean Segoe UI typography, intuitive layout, Title Case capitalization for all elements, and dark-mode diagnostic console.
- **Brand Identity & Iconography**: New ultra-high-resolution custom icon (multi-resolution `.ico` up to 256x256) and modern GitHub presentation assets.
- **Comprehensive SMTP Authentication**: Added support for credentials (Username and Password) with interactive show/hide password toggle.
- **Modern TLS / SSL Encryption**: Full support for `TLS 1.2` and `TLS 1.3`, with security modes for `Auto Detect`, `None (Plain)`, `SSL / TLS (Implicit 465)`, and `STARTTLS (Explicit 587)`.
- **Quick Port Selection**: One-click preset buttons for standard SMTP ports: `[25 SMTP]`, `[465 SSL]`, `[587 STARTTLS]`, and `[2525 Alt]`.
- **Server Profiles & Presets**: Pre-configured server presets for Gmail, Outlook / Office 365, Amazon SES, Yahoo Mail, and Localhost, with the ability to create, save, and delete custom profiles.
- **Message Delivery History Tab**: Dedicated delivery log with timestamp, recipient, sender, subject, duration, and server response codes.
- **Deep Message Inspector Dialog**: Double-click any delivery history item to view formatted message content, raw MIME headers, base64 payload, and step-by-step SMTP handshake transcripts.
- **Live HTML Preview**: Embedded HTML rendering engine enabling real-time preview of rich HTML emails before transmission.
- **High-Deliverability Transactional Templates**: 8 brand-new, spam-free templates for Welcome emails, Password Resets, Order Receipts, 2FA codes, Server Alerts, and Newsletters.
- **Asynchronous Auto-Update Checker**: Background check against GitHub releases on application startup with non-blocking UI notifications.
- **Open Tracking & Read Receipt Simulation**: Optional 1x1 transparent tracking pixel injection and `Disposition-Notification-To` delivery receipt request.

#### Changed
- **Version Reset**: Reset versioning cleanly to `v1.0` (two-digit convention: 1.0).
- **Target Framework**: Upgraded to standard `.NET Framework 4.8` for seamless compatibility across Windows 7 SP1, Windows 8, Windows 8.1, Windows 10, and Windows 11.
- **Output Executable**: Renamed output binary to `SMTPTool.exe`.
- **License & Copyright**: Updated license to MIT under Ali Sakkaf.

#### Removed
- Removed legacy `Ionic.Zlib` broken dependency and proprietary `.qa` quarantine files.
- Removed legacy spam/malware test templates (EICAR, macro payloads, GTUBE).
- Removed legacy build artifacts and obsolete bin folders.
