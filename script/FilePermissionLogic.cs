// using System.IO;
// using System.Security.AccessControl;
// using UnityEngine;

// public class FilePermissionLogic : MonoBehaviour
// {
//     public string filePath;
//     public FileSystemRights correctPermissions;

//     void Start()
//     {
//         CheckFilePermissions();
//     }

//     void CheckFilePermissions()
//     {
//         // Retrieve the file's ACL
//         FileSecurity fileSecurity = File.GetAccessControl(filePath);
//         FileSystemAccessRule accessRule = fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier))[0];

//         // Check if the file permissions are correct
//         if (accessRule.FileSystemRights != correctPermissions)
//         {
//             // Display an error message or prompt the player to fix the permissions
//             Debug.LogError("Incorrect file permissions. Please fix the permissions to progress to the next room.");
//         }
//     }

//     void ChangeFilePermissions(FileSystemRights newPermissions)
//     {
//         // Retrieve the file's ACL
//         FileSecurity fileSecurity = File.GetAccessControl(filePath);

//         // Create a new access rule with the new permissions
//         FileSystemAccessRule accessRule = new FileSystemAccessRule(
//             "Everyone",
//             newPermissions,
//             InheritanceFlags.None,
//             PropagationFlags.None,
//             AccessControlType.Allow
//         );

//         // Replace the existing access rule with the new one
//         fileSecurity.SetAccessRule(accessRule);

//         // Update the file's ACL with the new access rule
//         File.SetAccessControl(filePath, fileSecurity);
//     }
// }
