﻿using Business.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common.Cloud;
using DatingApp.Common.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
            config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "movies"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            if (uploadResult.Error != null)
            {
                throw new ApiException
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = uploadResult.Error.Message,
                };
            }
            return uploadResult;
        }

        public async Task DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            if (result.Error != null)
            {
                throw new ApiException
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = result.Error.Message
                };
            }

        }
    }
}
