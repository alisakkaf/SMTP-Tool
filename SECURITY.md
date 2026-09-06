# Security Policy

## Supported Versions

The table below summarizes security support across versions of **SMTP Tool**:

| Version | Supported          | Security Status |
| ------- | ------------------ | --------------- |
| 1.0.x   | :white_check_mark: | Active Support  |
| < 1.0   | :x:                | Deprecated      |

---

## Reporting a Vulnerability

We take the security of **SMTP Tool** seriously. If you identify a security issue, vulnerability, or potential exploit in SMTP Tool, please follow these responsible disclosure steps:

1. Submit a security fix or report directly via a **[GitHub Pull Request](https://github.com/alisakkaf/SMTP-Tool/pulls)** or **[GitHub Issues](https://github.com/alisakkaf/SMTP-Tool/issues)**.
2. If the issue is critical, submit a pull request with the recommended patch or open an issue labeled as a security advisory.
3. Include detailed steps to reproduce the issue, sample configurations, and affected versions.
4. Contributions and pull requests addressing security vulnerabilities will be reviewed and merged promptly into the next release.

---

## Best Practices for SMTP Testing

- **Do not hardcode or commit sensitive production credentials** into public configuration files.
- Use dedicated app-specific passwords when testing against services like Google Gmail or Microsoft 365.
- Always use TLS 1.2 or TLS 1.3 encryption when transmitting sensitive authentication tokens over public networks.
